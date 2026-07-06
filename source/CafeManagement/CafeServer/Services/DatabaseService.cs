using CafeCommon;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CafeServer.Services
{
    public static class DatabaseService
    {
        private static string url;
        private static string key;
        private static Client _supabase;
        private static Task _initializationTask;
        public static Client Client
        {
            get
            {
                if (_supabase == null)
                {
                    throw new Exception("Database chưa được khởi tạo! Hãy gọi InitializeAsync() trước.");
                }
                return _supabase;
            }
        }

        public static async Task InitializeAsync()
        {
            if (_supabase != null) return;

            if (_initializationTask != null)
            {
                await _initializationTask;
                return;
            }
            _initializationTask = Task.Run(async () =>
            {
                try
                {
                    // 1. Đọc nội dung file appsettings.json
                    string jsonConfig = File.ReadAllText("appsettings.json");

                    // 2. Parse JSON để lấy giá trị ra
                    JObject config = JObject.Parse(jsonConfig);
                    url = (string)config["SupabaseSettings"]["Url"];
                    key = (string)config["SupabaseSettings"]["ServiceRoleKey"];

                    // 3. Khởi tạo Supabase bằng Key lấy từ file
                    var options = new SupabaseOptions { AutoConnectRealtime = true };
                    _supabase = new Client(url, key, options);
                    await _supabase.InitializeAsync();

                    Console.WriteLine("--- Kết nối Supabase thành công (Service Role Key)! ---");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LỖI KẾT NỐI DB] Không thể đọc cấu hình hoặc khởi tạo Supabase: {ex.Message}");
                }
            });
            await _initializationTask;
        }
    }
}
