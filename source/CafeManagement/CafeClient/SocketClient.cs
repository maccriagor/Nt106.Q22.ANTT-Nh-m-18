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

                // Đảm bảo tuần tự IO để tránh tranh đọc với StartListening
                await _ioLock.WaitAsync();
                try
                {
                    byte[] dataSend = Encoding.UTF8.GetBytes(message);
                    await _stream.WriteAsync(dataSend, 0, dataSend.Length);

                    var responseBuilder = new StringBuilder();
                    byte[] buffer = new byte[4096];
                    int bytesRead = 0;

                    // Đọc ít nhất một lần (server trả ngay) và tiếp tục nếu còn DataAvailable
                    do
                    {
                        bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                            responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                    } while (_stream.DataAvailable);

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
                // Không tự động Disconnect ở đây để tránh server đánh offline nếu temporary error
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
                        // Giữ quyền đọc để không tranh với SendRequestAsync
                        await _ioLock.WaitAsync(token);
                        try
                        {
                            // Đọc chờ (blocking) - nếu server không gửi gì, ReadAsync sẽ chờ
                            int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, token);
                            if (bytesRead > 0)
                            {
                                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim('\0', '\r', '\n', '\uFEFF', '\u200B');

                                // Nếu đây là một phản hồi dành cho một request sync (có pipe '|' thường),
                                // StartListening vẫn có thể nhận được, nhưng vì chúng ta serialize IO bằng _ioLock,
                                // thường chỉ nhận push (broadcast) khi không có request đang chờ.
                                OnMessageReceived?.Invoke(message);
                            }
                            else
                            {
                                // bytesRead == 0 nghĩa là kết nối đã đóng
                                break;
                            }
                        }
                        finally
                        {
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
