using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BCrypt.Net;

namespace CafeCommon
{
    public static class SercurityHelper
    {
        public static string HashPassword(string password)
        {
            // BCrypt sẽ tự động tạo Salt và tích hợp vào chuỗi kết quả
            // WorkFactor mặc định là 11 (càng cao càng an toàn nhưng càng chậm)
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // 2. Hàm dùng để kiểm tra mật khẩu (Dùng khi Đăng nhập)
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Hàm này sẽ tự tách Salt từ hashedPassword và kiểm tra
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
