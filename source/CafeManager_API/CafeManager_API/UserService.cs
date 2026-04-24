using CafeManager_API;
using CafeManager_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MailKit.Net.Smtp;
using MimeKit;

namespace CafeManager_API
{

    public class UserService
    {
        // 1. API Đăng nhập
        public async Task<Account> LoginAsync(string user, string pass)
        {
            var result = await SupabaseManager.Client.From<Account>()
                .Where(x => x.Username == user && x.Password == pass)
                .Get();
            return result.Models.FirstOrDefault();
        }

        // 2. API Lấy thông tin cá nhân (Profile)
        public async Task<Employee> GetProfileAsync(int accId)
        {
            var result = await SupabaseManager.Client.From<Employee>()
                .Where(x => x.AccId == accId)
                .Get();
            return result.Models.FirstOrDefault();
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            // Regex chuẩn để check định dạng example@domain.com
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public async Task<bool> RegisterAsync(string user, string pass, string email, string phone, string fullName, string role)
        {
            try
            {
                if (!IsValidEmail(email))
                {
                    throw new Exception("Định dạng Email không hợp lệ !");
                }
                // Giai đoạn 1: Tạo tài khoản trong bảng account
                var newAccount = new Account
                {
                    Username = user,
                    Password = pass, // Khoa có thể dùng BCrypt để hash chỗ này
                    Email = email,
                    PhoneNumber = phone,
                    Role = role,
                    CreateDat = DateTime.Now
                };

                // Insert và lấy lại thông tin account vừa tạo (để có accid)
                var accResponse = await SupabaseManager.Client.From<Account>().Insert(newAccount);
                var createdAcc = accResponse.Models.FirstOrDefault();

                if (createdAcc == null) return false;

                // Giai đoạn 2: Dựa vào Role để tạo Profile tương ứng
                if (role == "Customer")
                {
                    var newCust = new Customers
                    {
                        AccId = createdAcc.AccId,
                        FullName = fullName,
                        PhoneNumber = phone,
                        Points = 0
                    };
                    await SupabaseManager.Client.From<Customers>().Insert(newCust);
                }
                else // Admin, Waiter, Kitchen
                {
                    var newEmp = new Employee
                    {
                        AccId = createdAcc.AccId,
                        FullName = fullName,
                        PhoneNumber = phone
                    };
                    await SupabaseManager.Client.From<Employee>().Insert(newEmp);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message);
                return false;
            }
        }



        public async Task<string> SendOtpEmailAsync(string targetEmail)
        {
            try
            {
                // 1. Tạo mã OTP ngẫu nhiên 6 số
                string otp = new Random().Next(100000, 999999).ToString();

                // 2. Cấu hình nội dung Email
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Cafe Manager UIT", "khoa@gmail.com"));
                message.To.Add(new MailboxAddress("User", targetEmail));
                message.Subject = "Mã xác nhận khôi phục mật khẩu";
                message.Body = new TextPart("plain")
                {
                    Text = $"Chào bạn,\n\nMã OTP để đặt lại mật khẩu của bạn là: {otp}\n" +
                           "Vui lòng không cung cấp mã này cho bất kỳ ai."
                };

                // 3. Gửi Email qua SMTP Gmail
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    // Dùng App Password của Google (16 ký tự)
                    await client.AuthenticateAsync("khoa@gmail.com", "your_app_password");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                return otp; // Trả về mã để so sánh tại Form
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi gửi mail: " + ex.Message);
            }
        }
    }
}
