using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text.Json;

namespace CafeClient
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = checkBxShowPass.Checked ? '\0' : '*';
            txtconPass.PasswordChar = checkBxShowPass.Checked ? '\0' : '*';
        }

        private async void btnReg_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra rỗng (Validation)
            if (string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpassword.Text) ||
                string.IsNullOrWhiteSpace(txtfullname.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) || cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ các thông tin", "Thông báo");
                return;
            }

            // 2. Kiểm tra mật khẩu nhập lại
            if (txtpassword.Text != txtconPass.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi");
                return;
            }

            try
            {
                btnReg.Enabled = false;

                // 3. Lấy giá trị Role từ ComboBox
                // Giả sử ComboBox có: "Phục vụ", "Bếp" -> Chuyển thành "Waiter", "Kitchen" để khớp DB
                string roleDisplay = cbRole.SelectedItem.ToString();
                string roleValue = (roleDisplay == "Phục vụ") ? "Waiter" : "Kitchen";

                // 4. Đóng gói chuỗi gửi đi
                string request = $"REGISTER|{txtusername.Text.Trim()}|{txtpassword.Text.Trim()}|{txtEmail.Text.Trim()}|{txtSDT.Text.Trim()}|{txtfullname.Text.Trim()}|{roleValue}";

                // 5. Gửi qua Socket
                string response = await SocketClient.SendRequestAsync(request);
                string[] res = response.Split('|');

                if (res[0] == "REGISTER_SUCCESS")
                {
                    MessageBox.Show(res[1], "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Quay lại form Login
                    Login loginform = new Login();
                    loginform.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(res[1], "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            txtfullname.Text = "";
            txtEmail.Text = "";
            txtconPass.Text = "";
            txtpassword.Text = "";
            txtSDT.Text = "";
            txtusername.Text = "";
            cbRole.SelectedIndex = 0;

        }
    }
}
