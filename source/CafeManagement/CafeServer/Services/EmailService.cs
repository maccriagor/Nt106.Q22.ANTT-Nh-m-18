using System.Net;
using System.Net.Mail;

namespace CafeServer
{
    public static class EmailService
    {
        public static async Task SendOtpAsync(string targetEmail, string otpCode)
        {

            //Nội dung email để có thể gửi OTP
            string fromEmail = "khoadungkhanh2006@gmail.com";
            //Cần appPassword để không bị google chặn
            string appPassword = "exlcfgdyqqeuxkam";

            //Chuẩn bị thông tin để server có thể gửi OTP
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                //Port để server gửi OTP
                Port = 587,
                //Thông tin chứng thực gồm email người dùng và app password
                Credentials = new NetworkCredential(fromEmail, appPassword),

                //Mã hóa nội dung gửi đến google server
                EnableSsl = true,
            };

            //Nội dung mail
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, "Cafe Management System"),
                Subject = "Mã xác thực OTP của bạn",
                Body = $"<h3>Mã OTP của bạn là: <b>{otpCode}</b></h3><p>Vui lòng nhập mã này vào ứng dụng để đặt lại mật khẩu.</p>",
                IsBodyHtml = true,
            };

            //Thao tác gửi mail chứa OTP đến người dùng
            mailMessage.To.Add(targetEmail);
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}