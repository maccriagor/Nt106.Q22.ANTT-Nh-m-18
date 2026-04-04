using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;

namespace CafeServer
{
    public class DatabaseService
    {
        private static string url = "https://alcocggifvzlrjdcvjeo.supabase.co";
        private static string key = "sb_publishable_StzdBcwl9tH1ys21QCElsg_X8FJLB48";
        public static Client Client { get; private set; }

        public static async Task InitializeAsync()
        {
            var options = new SupabaseOptions { AutoConnectRealtime = true };
            Client = new Client(url, key, options);
            await Client.InitializeAsync();
        }
    }
}
