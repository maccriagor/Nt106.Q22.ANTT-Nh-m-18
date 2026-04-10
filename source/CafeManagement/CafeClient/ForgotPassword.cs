using Supabase.Gotrue.Mfa;

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

        private async void btnReg_Click(object sender, EventArgs e) //OTP
        {
            string emailInput = txtusername.Text.Trim();
            if (string.IsNullOrWhiteSpace(emailInput))
            {
                MessageBox.Show("Vui lòng nhập Email để nhận OTP!", "Thông báo");
                return;
            }

            try
            {
                btnReg.Enabled = false;

                //Kiểm tra xem email có tồn tại trong database không
                //Lệnh kiểm tra email | email cần được kiểm tra 
                string request = $"CHECK_EMAIL|{emailInput}";
                string response = await CafeClient.SocketClient.SendRequestAsync(request);

                //Chia phản hồi cho request ở trên ra làm nhiều phần, chỉ quan trọng phần đầu tiên về status
                string[] res = response.Split('|');

                //res[0] chứa nội dung chính của phản hồi
                if (res[0] == "EMAIL_EXISTS")
                {
                    MessageBox.Show("Email hợp lệ. Đang gửi mã OTP...", "Thành công");
                }
                else if (res[0] == "EMAIL_NOT_FOUND")
                {
                    MessageBox.Show("Email này chưa được đăng ký trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + res[1], "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                btnReg.Enabled = true;
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            //Tạo request để gửi lên database của Supabase
            // Lệnh xác thực OTP | Email người dùng | Mã OTP
            string request = $"VERIFY_OTP|{txtusername.Text.Trim()}|{txtpassword.Text.Trim()}";
            string response = await SocketClient.SendRequestAsync(request);

            if (response == "VERIFY_SUCCESS")
            {
                MessageBox.Show("Mã chính xác! Bây giờ bạn có thể nhập mật khẩu mới.");
                
                // Do 1 nửa trang xác thực OTP không hiện ra trước khi xác nhận OTP
                //Nên khi ấn nút xác nhận, phần còn lại của UI sẽ hiện ra
                txtNewPass.Enabled = true;
                txtConfirmPass.Enabled = true;
                btnUpdate.Enabled = true;
                txtNewPass.Visible = true;
                txtConfirmPass.Visible = true;
                btnUpdate.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                txtNewPass.Enabled = true;
                txtConfirmPass.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng hoặc đã hết hạn.");
            }

           
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNewPass.Text)) return;
            //kiểm tra mật khẩu nhập lần hai
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return;
            }

            // Tạo request update mật khẩu mới được reset
            //Lệnh update mật khẩu | email người dùng | Mật khẩu mới nhập 
            string request = $"UPDATE_PASSWORD|{txtusername.Text}|{txtNewPass.Text}";
            string response = await SocketClient.SendRequestAsync(request);

            if (response == "UPDATE_SUCCESS")
            {
                MessageBox.Show("Đổi mật khẩu thành công! Hãy đăng nhập lại.");
            }
        }
    }
}
