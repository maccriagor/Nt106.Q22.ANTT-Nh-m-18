using CafeCommon;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeServer
{
    public class DatabaseService
    {
        private static string url = "https://alcocggifvzlrjdcvjeo.supabase.co";
        private static string key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImFsY29jZ2dpZnZ6bHJqZGN2amVvIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc3NDUxMTI5MywiZXhwIjoyMDkwMDg3MjkzfQ.JAFtQCMGmv4OKWy1PknhXwhnFfP-r5zszf_-vUsW5ow";
        private static Client _supabase;
        public static Client Client => _supabase;

        public static async Task InitializeAsync()
        {
            if (_supabase != null) return;
            var options = new SupabaseOptions { AutoConnectRealtime = true };
            _supabase = new Client(url, key, options);
            await _supabase.InitializeAsync();

            System.Console.WriteLine("--- Kết nối Supabase thành công! ---");
        }

        

        
    }
}
