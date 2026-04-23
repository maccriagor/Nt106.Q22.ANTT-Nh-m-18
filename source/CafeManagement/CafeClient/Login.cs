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
            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnLogin.Enabled = false;

                string request = $"LOGIN|{txtusername.Text.Trim()}|{txtpassword.Text.Trim()}";
                string response = await SocketClient.SendRequestAsync(request);

                if (response.StartsWith("ERROR"))
                {
                    MessageBox.Show("Lỗi kết nối: " + response.Split('|')[1], "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tách chuỗi phản hồi thành mảng
                string[] result = response.Split('|');
                string status = result[0];

                if (status == "LOGIN_SUCCESS")
                {
                    // Kiểm tra xem Server gửi đủ món không (ví dụ 7 phần tử)
                    if (result.Length >= 7)
                    {

                        UserSession.MaNguoiDung = int.Parse(result[1]);
                        UserSession.HoTen = result[2];
                        UserSession.TenDangNhap = result[3];
                        UserSession.Email = result[4];
                        UserSession.VaiTro = result[5];
                        UserSession.SDT = result[6];

                        string role = UserSession.VaiTro;
                        string fullName = UserSession.HoTen;

                        MessageBox.Show($"Chào mừng {fullName} ({role}) quay trở lại!", "Thành công");


                        this.Hide();


                        if (role == "Admin")
                        {
                            AdminMain form = new AdminMain();
                            form.Show();
                        }
                        else if (role == "Waiter")
                        {
                            WaiterMain form = new WaiterMain();
                            form.Show();
                        }
                        else if (role == "Kitchen")
                        {
                            KitchenMain form = new KitchenMain();
                            form.Show();
                        }


                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu Server gửi về không đủ!", "Lỗi giao thức");
                    }
                }
                else if (status == "LOGIN_FAIL")
                {
                    string message = result.Length > 1 ? result[1] : "Sai tài khoản hoặc mật khẩu!";
                    MessageBox.Show(message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống");
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void lbForgotPass_Click(object sender, EventArgs e)
        {
            ForgotPassword forrmm = new ForgotPassword();
            this.Hide();
            forrmm.ShowDialog();
            this.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxShowPass.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtusername.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
