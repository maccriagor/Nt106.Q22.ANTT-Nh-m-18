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
            catch { return false; }
        }

        public static async Task<string> SendRequestAsync(string message)
        {
            try
            {
                if (!await ConnectAsync()) return "ERROR|Không thể kết nối Server";

                byte[] dataSend = Encoding.UTF8.GetBytes(message);
                await _stream.WriteAsync(dataSend, 0, dataSend.Length);

                StringBuilder responseBuilder = new StringBuilder();
                byte[] buffer = new byte[4096]; // Tăng buffer lên 4KB để đọc nhanh hơn
                int bytesRead;

                do
                {
                    bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                    }

                    // Nếu dữ liệu vẫn còn trên luồng thì tiếp tục đọc
                } while (_stream.DataAvailable);

                return responseBuilder.ToString().Trim('\0', ' ', '\r', '\n');
            }
            catch (Exception ex)
            {
                Disconnect();
                return $"ERROR|{ex.Message}";
            }
        }

        public static void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
            _client = null;
            _stream = null;
        }
    }
}
