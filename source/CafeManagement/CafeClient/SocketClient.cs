using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CafeClient
{
    public static class SocketClient
    {
        private static string _ip = "127.0.0.1"; // IP của máy chạy Server
        private static int _port = 8888;

        public static async Task<string> SendRequestAsync(string message)
        {
            try
            {
                using TcpClient client = new TcpClient();
                // Kết nối tới Server
                await client.ConnectAsync(_ip, _port);

                using NetworkStream stream = client.GetStream();

                // 1. Gửi dữ liệu đi
                byte[] dataSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataSend, 0, dataSend.Length);

                // 2. Nhận phản hồi về
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
            catch (Exception ex)
            {
                return $"ERROR|{ex.Message}";
            }
        }
    }
}
