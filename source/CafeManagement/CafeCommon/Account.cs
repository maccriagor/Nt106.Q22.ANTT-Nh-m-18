namespace CafeCommon
{
    public class Account //này là dữ liệu mẫu thôi
    {
        public string Username { get; set; }
        public string Password { get; set; } // Sẽ được Hash SHA256
        public string Email { get; set; }
        public string Role { get; set; } // Admin, Waiter, Kitchen...
    }
}

