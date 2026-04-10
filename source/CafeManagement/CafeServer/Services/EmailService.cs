using System.Net;
using System.Net.Mail;

namespace CafeServer
{
    public static class EmailService
    {
        public static async Task SendOtpAsync(string targetEmail, string otpCode)
        {
            string fromEmail = "khoadungkhanh2006@gmail.com";
            string appPassword = "exlcfgdyqqeuxkam"; 
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