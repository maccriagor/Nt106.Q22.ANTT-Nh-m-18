using CafeCommon;
using System;
using System.Collections.Concurrent; // Required for ConcurrentDictionary
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace CafeServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Khởi tạo kết nối Database
            Console.WriteLine("Đang kết nối Supabase...");
            await DatabaseService.InitializeAsync();
            Console.WriteLine("--- Kết nối Supabase thành công! ---");

            SocketServer server = new SocketServer();
            server.Start();
            Console.WriteLine("--- HỆ THỐNG ĐÃ SẴN SÀNG NHẬN KẾT NỐI ---");

            // 3. Giữ cho Console không bị đóng
            Console.ReadLine();
        }

      
    }
}