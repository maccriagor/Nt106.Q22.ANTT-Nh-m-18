using CafeCommon;
using System.Net.Sockets;
using System.Text.Json;
namespace CafeClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Register registerform = new Register();
            registerform.Show();
            this.Hide();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Check if the user actually typed something (Basic validation)
            if (string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return;
            }

            try
            {
                // 1. Kết nối tới Server (check IP/Port cho đúng nhé)
                TcpClient client = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = client.GetStream();

                // 2. Chuẩn bị dữ liệu Đăng nhập
                var loginReq = new LoginRequest
                {
                    TenDangNhap = txtusername.Text,
                    MatKhau = SecurityHelper.HashPassword(txtpassword.Text)
                };

                // 3. Đóng gói và GỬI (Send)
                var packet = NetworkPacket<LoginRequest>.Create(PacketType.Login, loginReq);
                string json = JsonSerializer.Serialize(packet);
                byte[] data = System.Text.Encoding.UTF8.GetBytes(json);
                await stream.WriteAsync(data, 0, data.Length);

                // 4. ĐỢI PHẢN HỒI (Receive)
                byte[] responseBuffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                string responseJson = System.Text.Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                // Giải mã gói tin phản hồi
                var responsePacket = JsonSerializer.Deserialize<NetworkPacket<LoginResponse>>(responseJson);

                if (responsePacket != null && responsePacket.Payload.IsSuccess)
                {
                    // Đăng nhập thành công -> Lưu thông tin vào Session
                    UserSession.Token = responsePacket.Payload.Token;
                    UserSession.FullName = responsePacket.Payload.FullName;
                    UserSession.Role = responsePacket.Payload.Role;

                    MessageBox.Show($"Đăng nhập thành công! Chào {UserSession.FullName}");

                    // Chuyển Form tùy theo Role
                    NavigateToDashboard(UserSession.Role);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + (responsePacket?.Payload.Message ?? "Tài khoản không tồn tại"));
                    client.Close(); // Thất bại thì đóng kết nối
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến Server Cafe: " + ex.Message);
            }
        }

        private void NavigateToDashboard(string role)
        {
            switch (role)
            {
                case "Admin":
                    new AdminMain().Show();
                    break;
                case "Waiter":
                    new WaiterMain().Show();
                    break;
                case "Kitchen":
                    new KitchenMain().Show();
                    break;
                default:
                    MessageBox.Show("Vai trò không hợp lệ!");
                    break;
            }
        }

        private void lbForgotPass_Click(object sender, EventArgs e)
        {
            ForgotPassword forrmm = new ForgotPassword();
            forrmm.Show();
            this.Hide();
        }
    }
}
