using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClient
{
    public static class UserSession
    {
        public static string Token { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }
        public static bool IsLoggedIn => !string.IsNullOrEmpty(Token);
    }
}
