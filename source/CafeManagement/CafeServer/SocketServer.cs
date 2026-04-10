using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CafeServer.Services;
using CafeCommon;

namespace CafeServer
{
    public class SocketServer
    {
        private TcpListener _listener;
        private int _port = 8888;
        private bool _isRunning;
        public static System.Collections.Concurrent.ConcurrentDictionary<string, string> OtpStorage = new System.Collections.Concurrent.ConcurrentDictionary<string, string>();
        public void Start()
        {
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();
            _isRunning = true;
            Console.WriteLine($"[SERVER] Đang lắng nghe tại cổng {_port}...");

            // Vòng lặp chấp nhận kết nối từ các máy khách
            Task.Run(async () =>
            {
                while (_isRunning)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();
                    Console.WriteLine($"[SERVER] Một Client mới đã kết nối: {client.Client.RemoteEndPoint}");

                    // Tạo một luồng riêng để xử lý mỗi Client
                    _ = Task.Run(() => HandleClient(client));
                }
            });
        }

        private async void HandleClient(TcpClient client)
        {
            using NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim('\0', ' ', '\r', '\n');
                    Console.WriteLine($"[CLIENT SAYS]: {request}");

                    // XỬ LÝ AUTH TẠI ĐÂY
                    string response = await ProcessRequest(request);

                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        private async Task<string> ProcessRequest(string request)
        {
            // Định dạng gói tin: COMMAND|DATA1|DATA2|...
            string[] parts = request.Split('|');
            if (parts.Length == 0)
                return "ERROR|Invalid request";

            string command = parts[0];

            switch (command)
            {
                case "LOGIN":
                    if (parts.Length < 3)
                        return "LOGIN_FAIL|Thiếu thông tin";
                    var account = await ServiceManager.User.LoginAsync(parts[1], parts[2]);

                    if (account != null)
                    {
                        // Thứ tự dữ liệu: 0:Status | 1:MaND | 2:HoTen | 3:TenDN | 4:Email | 5:VaiTro | 6:SDT
                        return $"LOGIN_SUCCESS|{account.MaNguoiDung}|{account.HoTen}|{account.TenDangNhap}|{account.Email}|{account.VaiTro}|{account.SDT}";
                    }
                    else
                    {
                        return "LOGIN_FAIL|Sai tên đăng nhập hoặc mật khẩu";
                    }

                case "REGISTER":
                    // Gói tin từ Client gửi lên: REGISTER|user|pass|email|phone|fullName|role
                    // parts[0] là "REGISTER"
                    if (parts.Length < 7) return "REGISTER_FAIL|Thiếu thông tin đăng ký!";

                    string regResult = await ServiceManager.User.RegisterAsync(
                        parts[1], // user
                        parts[2], // pass
                        parts[3], // email
                        parts[4], // phone
                        parts[5], // fullName
                        parts[6]  // role
                    );
                    return regResult;

                case "CHECK_EMAIL":
                    if (parts.Length < 2)
                        return "ERROR|Thiếu email";
                    string email = parts[1];

                    //1. check email có trong database không
                    bool exists = await UserService.IsEmailRegisteredAsync(email);

                    if (exists)
                    {
                        // 2. Tạo mã code OTP 6 chữ số
                        string otpCode = new Random().Next(100000, 999999).ToString();
                        OtpStorage[email] = otpCode;

                        // 3. Gửi mail chứa OTP
                        try
                        {
                            await EmailService.SendOtpAsync(email, otpCode);
                            return "EMAIL_EXISTS|OTP_SENT";
                        }
                        catch (Exception ex)
                        {
                            return $"ERROR|Could not send email: {ex.Message}";
                        }
                    }
                    else
                    {
                        return "EMAIL_NOT_FOUND|Email này không tồn tại trong hệ thống";
                    }

            //xác thực otp
                case "VERIFY_OTP":

                    // lệnh xác thực otp : $"VERIFY_OTP|{txtusername.Text.Trim()}|{txtpassword.Text.Trim()}";
                    // mỗi dấu | chia lệnh ra 1 part
                    //Nếu không đủ 3 part sẽ thiếu dữ liệu

                    if (parts.Length < 3) return "VERIFY_FAIL";

                    //Trim làm gọn dữ liệu của email và mã otp
                    string emailKey = parts[1].Trim();
                    string userOtp = parts[2].Trim();

                    if (OtpStorage.TryGetValue(emailKey, out string actualOtp))//Lấy mã otp được đưa cho mail tương ứng
                    {
                        if (actualOtp == userOtp) //so sánh mã otp được nhập và mã otp được gửi
                        {
                            return "VERIFY_SUCCESS";
                        }
                    }
                    return "VERIFY_FAIL";


                    //quên mật khẩu
                case "UPDATE_PASSWORD":

                    // lệnh update password : $"UPDATE_PASSWORD|{txtusername.Text}|{txtNewPass.Text}";
                    // mỗi dấu | chia lệnh ra 1 part
                    //Nếu không đủ 3 part sẽ thiếu dữ liệu
                    if (parts.Length < 3) return "UPDATE_FAIL|Missing data";

                    //1.Trim làm gọn dữ liệu của Email người dùng + mật khẩu mới
                    string targetEmail = parts[1].Trim();
                    string newPasswordRaw = parts[2].Trim();
                    //2.Hash password mới được cập nhập
                    string hashedNewPassword = CafeCommon.SercurityHelper.HashPassword(newPasswordRaw);
                    //3.Thay password của mail người dùng với password mới 
                    bool isUpdated = await UserService.UpdateUserPasswordAsync(targetEmail, hashedNewPassword);
                    if (isUpdated)
                    {
                        return "UPDATE_SUCCESS";
                    }
                    else
                    {
                        return "UPDATE_FAIL|Database update failed";
                    }
                default:
                    return "UNKNOWN_COMMAND";
            }
        }
    }
}
