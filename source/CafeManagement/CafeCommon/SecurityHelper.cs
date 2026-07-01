using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BCrypt.Net;
using System.IO;

namespace CafeCommon
{
    public static class SecurityHelper
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

        // =========================================================================
        // BẢO MẬT ĐƯỜNG TRUYỀN (SOCKET ENCRYPTION - AES 256)
        // =========================================================================

        // Key PHẢI ĐÚNG 32 ký tự (256 bits). IV PHẢI ĐÚNG 16 ký tự (128 bits).
        // Bạn có thể đổi chuỗi này thành bất kỳ chữ gì bạn thích miễn đủ số lượng ký tự.
        private static readonly byte[] AesKey = Encoding.UTF8.GetBytes("KhoaDung2026CafeProject@12345678");
        private static readonly byte[] AesIV = Encoding.UTF8.GetBytes("CafeSocket123456");

        // Hàm Mã hóa: Biến chữ thường thành chuỗi loằng ngoằng (Base64)
        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return plainText;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = AesKey;
                aesAlg.IV = AesIV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        // Hàm Giải mã: Dịch chuỗi loằng ngoằng về lại chữ thường
        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return cipherText;

            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = AesKey;
                    aesAlg.IV = AesIV;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
            catch
            {
                // Bẫy lỗi thông minh: Nếu đọc phải gói tin chưa mã hóa, 
                // hoặc giải mã thất bại, trả về nguyên gốc để Server không bị sập (Crash)
                return cipherText;
            }
        }
    }
}
