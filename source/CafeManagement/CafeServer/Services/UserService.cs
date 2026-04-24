using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeCommon;
using Supabase;
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
                    TrangThaiOnline = false,
                    NgayTao = DateTime.Now
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

        //Chỉnh sửa thông tin tài khoản
        public async Task<bool> UpdateProfileAsync(int userId, string fullName, string email)
        {
            try
            {
                // Cập nhật thông tin vào Supabase
                await DatabaseService.Client.From<UserAccount>()
                    .Where(x => x.MaNguoiDung == userId)
                    .Set(x => x.HoTen, fullName)
                    .Set(x => x.Email, email)
                    .Update();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
                return false;
            }
        }

        //Hàm lấy danh sách các nhân viên
        public async Task<List<UserAccount>> GetAllEmployeesAsync()
        {
            var result = await DatabaseService.Client.From<UserAccount>().Get();
            return result.Models;
        }
        //Hàm xóa nhân viên theo id
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            try
            {
                await DatabaseService.Client.From<UserAccount>().Where(x => x.MaNguoiDung == id).Delete();
                return true;
            }
            catch { return false; }
        }
        //Hàm update thông tin của nhân viên
        public async Task<bool> UpdateEmployeeBasicAsync(int id, string user, string name, string email, string pass, string role)
        {
            var update = DatabaseService.Client.From<UserAccount>().Where(x => x.MaNguoiDung == id)
                .Set(x => x.TenDangNhap, user).Set(x => x.HoTen, name).Set(x => x.Email, email).Set(x => x.VaiTro, role);
            if (!string.IsNullOrEmpty(pass)) update = update.Set(x => x.MatKhau, SercurityHelper.HashPassword(pass));
            await update.Update();
            return true;
        }
        //Hàm tìm kiếm nhân viên theo tên
        public async Task<List<UserAccount>> SearchEmployeesByNameAsync(string name)
        {
            var result = await DatabaseService.Client.From<UserAccount>()
                .Filter("hoten", Supabase.Postgrest.Constants.Operator.ILike, $"%{name}%").Get(); //ILike giúp tìm kiếm không phân biệt chữ hoa hay thường
            return result.Models;
        }
        //Hàm lấy tài khoản theo id
        public async Task<UserAccount> GetUserByIdAsync(int id)
        {
            try
            {
                // Truy vấn Supabase lấy 1 User dựa trên MaNguoiDung
                var result = await DatabaseService.Client.From<UserAccount>()
                    .Where(x => x.MaNguoiDung == id)
                    .Get();

                return result.Models.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR GetUserById]: {ex.Message}");
                return null;
            }
        }
    }
}
