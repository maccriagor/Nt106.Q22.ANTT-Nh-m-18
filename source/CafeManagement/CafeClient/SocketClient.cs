using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CafeClient
{
    public static class SocketClient
    {
        private static TcpClient _client;
        private static NetworkStream _stream;
        private static string _ip = "127.0.0.1"; // IP của máy chạy Server
        private static int _port = 8888;

        // Đồng bộ I/O: đảm bảo chỉ một tác vụ đọc/ghi lên stream tại một thời điểm
        private static readonly SemaphoreSlim _ioLock = new SemaphoreSlim(1, 1);

        // Dùng để hủy vòng lặp StartListening khi disconnect
        private static CancellationTokenSource _listenCts;

        // Sự kiện để các Form đăng ký lắng nghe tin push từ server
        public static event Action<string> OnMessageReceived;

        public static async Task<bool> ConnectAsync()
        {
            try
            {
                if (_client == null || !_client.Connected)
                {
                    _client = new TcpClient();
                    await _client.ConnectAsync(_ip, _port);
                    _stream = _client.GetStream();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<string> SendRequestAsync(string message)
        {
            try
            {
                if (!await ConnectAsync()) return "ERROR|Không thể kết nối Server";

                // Đảm bảo tuần tự IO để tránh tranh đọc
                await _ioLock.WaitAsync();
                try
                {
                    // 1. DỌN SẠCH BỘ ĐỆM (FLUSH): Đọc bỏ mọi dữ liệu rác còn kẹt lại
                    while (_stream.DataAvailable)
                    {
                        byte[] dump = new byte[1024];
                        await _stream.ReadAsync(dump, 0, dump.Length);
                    }

                    // 2. Gửi lệnh mới lên Server
                    byte[] dataSend = Encoding.UTF8.GetBytes(message);
                    await _stream.WriteAsync(dataSend, 0, dataSend.Length);

                    // 3. ĐỌC PHẢN HỒI AN TOÀN
                    var responseBuilder = new StringBuilder();
                    byte[] buffer = new byte[4096];

                    // Lần đọc đầu tiên: Sẽ chờ ở đây cho đến khi Server bắt đầu trả lời
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

                        // BÍ QUYẾT CHỐNG PHÂN MẢNH: Chờ đúng 30ms để các gói tin dài (nếu có) kịp chui hết vào bộ đệm
                        await Task.Delay(30);

                        // Sau 30ms, đọc vét tất cả những gì đang có sẵn trong bộ đệm rồi thoát ngay lập tức
                        while (_stream.DataAvailable)
                        {
                            bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead > 0)
                            {
                                responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                            }
                        }
                    }

                    string raw = responseBuilder.ToString();
                    return raw.Trim('\0', ' ', '\r', '\n', '\uFEFF', '\u200B');
                }
                finally
                {
                    _ioLock.Release();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SocketClient] SendRequestAsync error: {ex.Message}");
                return $"ERROR|{ex.Message}";
            }
        }

        // Bắt đầu luồng lắng nghe push từ server (RELOAD_TABLE_MAP, ...).
        // Gọi StartListening() 1 lần sau khi Login thành công.
        public static void StartListening()
        {
            // Nếu đã đang lắng nghe, không làm lại
            if (_listenCts != null && !_listenCts.IsCancellationRequested) return;

            _listenCts = new CancellationTokenSource();
            CancellationToken token = _listenCts.Token;

            Task.Run(async () =>
            {
                byte[] buffer = new byte[4096];
                while (!token.IsCancellationRequested && _client != null && _client.Connected)
                {
                    try
                    {
                        // 1. NGĂN CHẶN DEADLOCK: Đứng ngoài cửa nhìn.
                        // Nếu chưa có dữ liệu đẩy về từ Server, nhường CPU 50ms rồi quay lại nhìn tiếp.
                        // TUYỆT ĐỐI KHÔNG XIN KHÓA LÚC NÀY để các lệnh khác (GET_TABLES...) có thể chạy.
                        if (!_stream.DataAvailable)
                        {
                            await Task.Delay(50, token);
                            continue;
                        }

                        // 2. TÓM ĐƯỢC DỮ LIỆU: Xin khóa để đọc an toàn
                        await _ioLock.WaitAsync(token);
                        try
                        {
                            // Kiểm tra lại lần nữa cho chắc ăn sau khi có khóa
                            if (_stream.DataAvailable)
                            {
                                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, token);
                                if (bytesRead > 0)
                                {
                                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim('\0', '\r', '\n', '\uFEFF', '\u200B');

                                    // Kích hoạt sự kiện để Form giao diện cập nhật
                                    OnMessageReceived?.Invoke(message);
                                }
                                else
                                {
                                    // bytesRead == 0 nghĩa là kết nối đã đóng
                                    break;
                                }
                            }
                        }
                        finally
                        {
                            // Đọc xong lập tức trả lại Khóa (Micro) cho người khác dùng
                            _ioLock.Release();
                        }
                    }
                    catch (OperationCanceledException) { break; }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[SocketClient] Listening error: {ex.Message}");
                        break;
                    }
                }
            }, token);
        }

        public static void StopListening()
        {
            try
            {
                _listenCts?.Cancel();
                _listenCts?.Dispose();
            }
            catch { }
            _listenCts = null;
        }

        public static void Disconnect()
        {
            try
            {
                StopListening();
                _stream?.Close();
                _client?.Close();
            }
            catch { }
            finally
            {
                _stream = null;
                _client = null;
            }
        }
    }
}
