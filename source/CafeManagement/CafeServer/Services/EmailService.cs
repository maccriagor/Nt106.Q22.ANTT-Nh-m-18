using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace CafeServer.Services
{
    public static class EmailService
    {

        private static readonly IConfiguration _config;

        static EmailService()
        {
            // Tự động tìm và đọc file appsettings.json khi class được nạp
            _config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static async Task SendOtpAsync(string targetEmail, string otpCode)
        {
            string fromEmail = _config["EmailSettings:FromEmail"];
            string appPassword = _config["EmailSettings:AppPassword"];
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, appPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, "Cafe Management System"),
                Subject = "Mã xác thực OTP của bạn",
                Body = $"<h3>Mã OTP của bạn là: <b>{otpCode}</b></h3><p>Vui lòng nhập mã này vào ứng dụng để đặt lại mật khẩu.</p>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(targetEmail);
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
