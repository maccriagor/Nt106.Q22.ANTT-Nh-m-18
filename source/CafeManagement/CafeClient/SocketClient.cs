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

                byte[] buffer = new byte[1024];
                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
            catch (Exception ex) { return $"ERROR|{ex.Message}"; }
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
