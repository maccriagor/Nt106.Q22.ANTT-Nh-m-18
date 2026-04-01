using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    //public class NetworkPacket //này là dữ liệu mẫu thôi
    //{
    //public string Command { get; set; } // LOGIN, REGISTER, LOGOUT...
    //public string Data { get; set; }    // Chuỗi JSON chứa thông tin
    //}
    public class NetworkPacket<T>
    {
        // Add this instead: A simple success/fail flag for server responses
        // This makes the client-side UI logic (like showing a MessageBox) 10x easier.
        public bool Success { get; set; } = true;

        // Add this: A message for the user if something goes wrong
        public string Message { get; set; }

        // The type of action being performed
        public PacketType Command { get; set; }

        // The actual payload (could be a User object, an Order object, etc.)
        public T Payload { get; set; }

        // Metadata for debugging and synchronization
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        // Optional: Token for authenticated requests
        public string AuthToken { get; set; }

        // Helper method to wrap data quickly
        public static NetworkPacket<T> Create(PacketType command, T data, string token = null)
        {
            return new NetworkPacket<T>
            {
                Command = command,
                Payload = data,
                AuthToken = token
            };
        }
    }
    public enum PacketType
    {
        // Auth Actions
        Login,
        Logout,
        Register,

        // Management Actions
        GetMenu,
        UpdateStock,
        PlaceOrder,

        // Response Status
        Success,
        Error,
        SystemAlert
    }
}
