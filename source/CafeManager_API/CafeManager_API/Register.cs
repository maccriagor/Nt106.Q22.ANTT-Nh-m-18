using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManager_API
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UserService service = new UserService();

            // Kiểm tra dữ liệu đầu vào (Validation)
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!");
                return;
            }

            if (!service.IsValidEmail(textBox1.Text.Trim()))
            {
                MessageBox.Show("Email sai định dạng (ví dụ: tên@gmail.com)");
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò (Role)!");
                return;
            }

            button1.Enabled = false;
            button1.Text = "Processing...";

            try
            {
                // Khởi tạo kết nối (nếu chưa)
                await SupabaseManager.InitializeAsync();

                // Gọi hàm đăng ký
                bool isSuccess = await service.RegisterAsync(
                    textBox1.Text.Trim(),
                    textBox2.Text,
                    textBox3.Text.Trim(),
                    textBox5.Text.Trim(),
                    textBox4.Text.Trim(),
                    comboBox1.SelectedItem.ToString()
                );

                if (isSuccess)
                {
                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo");
                    this.Close(); // Đóng form quay lại Login
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại. Tài khoản có thể đã tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                button1.Enabled = true;
                button1.Text = "Register";
            }
        }
    }
}
