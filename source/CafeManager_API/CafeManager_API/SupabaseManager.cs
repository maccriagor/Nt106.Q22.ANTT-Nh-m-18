using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager_API
{
    public static class SupabaseManager
    {
        private const string Url = "https://alcocggifvzlrjdcvjeo.supabase.co";
        private const string Key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImFsY29jZ2dpZnZ6bHJqZGN2amVvIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzQ1MTEyOTMsImV4cCI6MjA5MDA4NzI5M30.HtmeWngOWBPY_pnXOzRK6FAyceqIjhgB6G29LtgZTpE";

        public static Supabase.Client Client { get; private set; }

        public static async Task InitializeAsync()
        {
            if (Client != null) return;
            var options = new Supabase.SupabaseOptions { AutoConnectRealtime = true };
            Client = new Supabase.Client(Url, Key, options);
            await Client.InitializeAsync();
        }
    }
}
