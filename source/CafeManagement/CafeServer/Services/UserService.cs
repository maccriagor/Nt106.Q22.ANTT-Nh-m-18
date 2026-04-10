using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeCommon;
using Supabase.Postgrest;

namespace CafeServer.Services
{
    public class UserService
    {
        // Hàm Login
        public async Task<UserAccount> LoginAsync(string username, string password)
        {
            try
            {
                var result = await DatabaseService.Client
                    .From<UserAccount>()
                    .Where(x => x.TenDangNhap == username)
                    .Get();

                var account = result.Models.FirstOrDefault();

                // Kiểm tra mật khẩu bằng BCrypt
                if (account != null && SercurityHelper.VerifyPassword(password, account.MatKhau))
                {
                    await UpdateOnlineStatusAsync(account.MaNguoiDung, true); // Chuyển sang Online
                    return account;
                }
                return null;
            }
            catch (Exception) { return null; }
        }

        //Hàm Register
        public async Task<string> RegisterAsync(string user, string pass, string email, string phone, string fullName, string role)
        {
            try
            {
                // 1. Kiểm tra xem Username hoặc Email đã tồn tại chưa
                var existingUser = await DatabaseService.Client.From<UserAccount>()
                    .Where(x => x.TenDangNhap == user || x.Email == email)
                    .Get();

                if (existingUser.Models.Count > 0)
                {
                    return "REGISTER_FAIL|Tên đăng nhập hoặc Email đã tồn tại!";
                }

                // 2. Mã hóa mật khẩu bằng BCrypt
                string hashedPass = SercurityHelper.HashPassword(pass);

                // 3. Tạo đối tượng mới
                var newUser = new UserAccount
                {
                    TenDangNhap = user,
                    MatKhau = hashedPass,
                    Email = email,
                    SDT = phone,
                    HoTen = fullName,
                    VaiTro = role,
                    TrangThaiOnline = false
                };

                // 4. Lưu vào Supabase
                await DatabaseService.Client.From<UserAccount>().Insert(newUser);

                return "REGISTER_SUCCESS|Đăng ký tài khoản thành công!";
            }
            catch (Exception ex)
            {
                return $"REGISTER_FAIL|Lỗi Server: {ex.Message}";
            }
        }

        // Hàm Cập nhật trạng thái Online
        public async Task<bool> UpdateOnlineStatusAsync(int userId, bool isOnline)
        {
            try
            {
                await DatabaseService.Client.From<UserAccount>()
                    .Where(x => x.MaNguoiDung == userId)
                    .Set(x => x.TrangThaiOnline, isOnline)
                    .Update();
                return true;
            }
            catch (Exception) { return false; }
        }

        //Kiểm tra email đã đki
        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            var result = await DatabaseService.Client.From<UserAccount>()
                .Where(x => x.Email == email)
                .Get();

            return result.Models.Count > 0;
        }

        //Cập nhật user password
        public async Task<bool> UpdateUserPasswordAsync(string email, string hashedPass)
        {
            try
            {
                await DatabaseService.Client.From<UserAccount>()
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
