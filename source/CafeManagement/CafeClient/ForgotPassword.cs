namespace CafeClient
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        

        private void label7_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.Show();
            this.Hide();
        }

        private void checkBxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxShowPass.Checked)
            {
                txtNewPass.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtConfirmPass.PasswordChar = '*';
                txtNewPass.PasswordChar = '*';
            }
        }

        private async void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = txtemailreset.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo");
                return;
            }

            btnSendOTP.Enabled = false;
            string response = await SocketClient.SendRequestAsync($"CHECK_EMAIL|{email}");
            string[] res = response.Split('|');

            if (res[0] == "EMAIL_EXISTS")
            {
                MessageBox.Show("Mã OTP đã được gửi vào Email của bạn.", "Thành công");
            }
            else
            {
                MessageBox.Show(res.Length > 1 ? res[1] : "Email không tồn tại!", "Lỗi");
            }
            btnSendOTP.Enabled = true;
        }

        private async void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string email = txtemailreset.Text.Trim();
            string otp = txtOTP.Text.Trim();

            if (string.IsNullOrEmpty(otp)) return;

            string response = await SocketClient.SendRequestAsync($"VERIFY_OTP|{email}|{otp}");

            if (response == "VERIFY_SUCCESS")
            {
                MessageBox.Show("Xác nhận thành công! Vui lòng nhập mật khẩu mới.", "Thông báo");
                txtNewPass.Visible = true;
                label5.Visible = true;
                label6.Visible  = true;
                checkBxShowPass.Visible = true;
                txtConfirmPass.Visible = true;
                btnUpdate.Visible = true;
                btnVerifyOTP.Enabled = false; // Khóa nút xác nhận lại
            }
            else
            {
                MessageBox.Show("Mã OTP không chính xác hoặc đã hết hạn!", "Lỗi");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi");
                return;
            }

            string email = txtemailreset.Text.Trim();
            string newPass = txtNewPass.Text.Trim();

            string response = await SocketClient.SendRequestAsync($"UPDATE_PASSWORD|{email}|{newPass}");

            if (response == "UPDATE_SUCCESS")
            {
                MessageBox.Show("Đổi mật khẩu thành công! Hãy quay lại đăng nhập.", "Thành công");
                Login loginform = new Login();
                loginform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại, vui lòng thử lại sau.", "Lỗi");
            }
        }
    }
}
