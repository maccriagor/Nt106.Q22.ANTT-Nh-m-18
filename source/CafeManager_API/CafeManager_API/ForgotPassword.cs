using CafeManager_API.Models;
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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        string generatedOTP = ""; // Biến lưu mã OTP vừa gửi
        private async void button1_Click(object sender, EventArgs e)
        {
            UserService service = new UserService();
            button1.Enabled = false;
            button1.Text = "Đang gửi...";

            try
            {
                generatedOTP = await service.SendOtpEmailAsync(textBox1.Text.Trim());
                MessageBox.Show("Mã OTP đã được gửi vào Email của bạn!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button1.Enabled = true;
                button1.Text = "Gửi mã";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == generatedOTP && !string.IsNullOrEmpty(generatedOTP))
            {
                // Cập nhật mật khẩu mới lên Supabase
                await SupabaseManager.Client.From<Account>()
                    .Where(x => x.Email == textBox1.Text.Trim())
                    .Set(x => x.Password, textBox3.Text) // Vì chưa làm Hash nên lưu text thuần
                    .Update();

                MessageBox.Show("Đặt lại mật khẩu thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã OTP không chính xác!");
            }
        }
    }
}
