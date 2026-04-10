using CafeCommon;
using CafeServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CafeServer
{
    public class SocketServer
    {
        private TcpListener _listener;
        private int _port = 8888;
        private bool _isRunning;

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

            // Biến nhớ ID của người dùng đang kết nối Socket
            int currentUserId = 0;

            try
            {
                while (client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"[CLIENT SAYS]: {request}");

                    string response = await ProcessRequest(request);

                    // Nếu lệnh LOGIN thành công --> ghi nhớ ID vào biến currentUserId
                    if (response.StartsWith("LOGIN_SUCCESS"))
                    {
                        string[] resParts = response.Split('|');
                        currentUserId = int.Parse(resParts[1]); // Lưu MaNguoiDung vào đây
                    }
                    // Nếu lệnh LOGOUT thành công --> xóa ID đi
                    else if (response == "LOGOUT_SUCCESS")
                    {
                        currentUserId = 0;
                    }

                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DISCONNECT] Client {client.Client.RemoteEndPoint} đã ngắt kết nối.");
            }
            finally
            {
                // khi kết nối đóng
                if (currentUserId != 0)
                {
                    // cập nhật Offline cho ID đã ghi nhớ
                    await ServiceManager.User.UpdateOnlineStatusAsync(currentUserId, false);
                    Console.WriteLine($"[STATUS] User ID {currentUserId} đã Offline.");
                }
                client.Close();
            }
        }

        private async Task<string> ProcessRequest(string request)
        {
            // Định dạng gói tin: COMMAND|DATA1|DATA2|...
            string[] parts = request.Split('|');
            string command = parts[0];

            switch (command)
            {
                case "LOGIN":
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

                case "LOGOUT":
                    // Dữ liệu: LOGOUT|manguoidung
                    int logoutId = int.Parse(parts[1]);
                    await ServiceManager.User.UpdateOnlineStatusAsync(logoutId, false);
                    return "LOGOUT_SUCCESS";

                case "CHECK_EMAIL":
                    if (parts.Length < 2)
                        return "ERROR|Thiếu email";
                    string email = parts[1];

                    // 1. Check Supabase via DatabaseService
                    bool exists = await DatabaseService.IsEmailRegisteredAsync(email);

                    if (exists)
                    {
                        // 2. Generate a 6-digit OTP
                        string otpCode = new Random().Next(100000, 999999).ToString();

                        // 3. Store it temporarily (to verify later)
                        OtpStorage[email] = otpCode;

                        // 4. Send the Email
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

                case "VERIFY_OTP":
                    if (parts.Length < 3) return "VERIFY_FAIL";
                    string emailKey = parts[1].Trim();
                    string userOtp = parts[2].Trim();
                    if (OtpStorage.TryGetValue(emailKey, out string actualOtp))
                    {
                        if (actualOtp == userOtp)
                        {
                            return "VERIFY_SUCCESS";
                        }
                    }
                    return "VERIFY_FAIL";

                case "UPDATE_PASSWORD":
                    if (parts.Length < 3) return "UPDATE_FAIL|Missing data";

                    string targetEmail = parts[1].Trim();
                    string newPasswordRaw = parts[2].Trim();
                    string hashedNewPassword = CafeCommon.SercurityHelper.HashPassword(newPasswordRaw);
                    bool isUpdated = await DatabaseService.UpdateUserPasswordAsync(targetEmail, hashedNewPassword);
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
