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

        public static async Task<bool> IsEmailRegisteredAsync(string email)
        {
            var modelMatch = new Dictionary<string, string>
            {
                  { "email", email } 
             };
            var result = await _supabase.From<UserAccount>()
                             .Match(modelMatch)
                             .Get();

            return result.Models.Count > 0;
        }

        public static async Task<bool> UpdateUserPasswordAsync(string email, string hashedPass)
        {
            try
            {
                await _supabase.From<UserAccount>()
                               .Where(x => x.Email == email)
                               .Set(x => x.MatKhau, hashedPass) 
                               .Update();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR]: {ex.Message}");
                return false;
            }
        }
    }
}
