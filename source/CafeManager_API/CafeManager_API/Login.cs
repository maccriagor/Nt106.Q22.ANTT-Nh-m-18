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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await SupabaseManager.InitializeAsync();
                UserService service = new UserService();

                var account = await service.LoginAsync(textBox1.Text.Trim(), textBox2.Text.Trim());

                if (account != null)
                {
                    var profile = await service.GetProfileAsync(account.AccId);
                    string name = profile?.FullName ?? account.Username;

                    MessageBox.Show($"Chào mừng {name} ({account.Role})!");
                    switch (account.Role)
                    {
                        case "Admin":
                            frmMain adminForm = new frmMain(name, account.Role);
                            adminForm.Show();
                            break;

                        case "Waiter":
                            frmMain waiterForm = new frmMain(name, account.Role);
                            waiterForm.Show();
                            break;

                        case "Kitchen":
                            frmMain kitchenForm = new frmMain(name, account.Role);
                            kitchenForm.Show();
                            break;

                        case "Customer":
                            frmMain customerForm = new frmMain(name, account.Role);
                            customerForm.Show();
                            break;
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản/mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mạng: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng Form đăng ký
            Register registerForm = new Register();

            // Hiển thị Form đăng ký dưới dạng Dialog 
            registerForm.ShowDialog();

            // Nếu muốn ẩn luôn form Login khi mở Register thì dùng:
            this.Hide();
            
            this.Show(); // Hiện lại sau khi đóng form Register
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ForgotPassword forgot = new ForgotPassword();
            forgot.ShowDialog();
        }
    }
}
