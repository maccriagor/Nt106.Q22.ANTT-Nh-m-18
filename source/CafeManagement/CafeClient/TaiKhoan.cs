using CafeCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeClient
{
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotForm = new ForgotPassword();

            DialogResult res = forgotForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                SocketClient.SendRequestAsync($"LOGOUT|{UserSession.MaNguoiDung}");

                // 2. Xóa Session và ngắt kết nối
                SocketClient.Disconnect();
                UserSession.Clear();

                Form adminMain = Application.OpenForms["AdminMain"];
                if (adminMain != null)
                {
                    adminMain.Hide();
                    Login login = new Login();
                    login.Show();
                    adminMain.Close();
                }
            }
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            txtfullname.Text = UserSession.HoTen;
            txtusername.Text = UserSession.TenDangNhap;
            txtSDT.Text = UserSession.SDT;
            txtEmail.Text = UserSession.Email;
            txtRole.Text = UserSession.VaiTro;
        }

        private async void btnUpdateProf_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtfullname.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Họ tên và Email không được để trống!", "Thông báo");
                return;
            }

            try
            {
                btnUpdateProf.Enabled = false;

                // 2. Gửi yêu cầu lên Server
                string request = $"UPDATE_PROFILE|{UserSession.MaNguoiDung}|{txtfullname.Text.Trim()}|{txtEmail.Text.Trim()}";
                string response = await SocketClient.SendRequestAsync(request);
                string[] res = response.Split('|');

                if (res[0] == "UPDATE_SUCCESS")
                {
                    // 3. QUAN TRỌNG: Cập nhật lại UserSession để các Form khác đồng bộ theo
                    UserSession.HoTen = txtfullname.Text.Trim();
                    UserSession.Email = txtEmail.Text.Trim();

                    MessageBox.Show(res[1], "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Cập nhật cái tên hiển thị ở Sidebar (Nếu cần)
                    // Vì Form này là con của AdminMain, bạn có thể gọi:
                    var mainForm = this.FindForm() as AdminMain; // Hoặc WaiterMain tùy role
                    if (mainForm != null)
                    {
                        // Giả sử bạn có hàm hoặc Label public ở AdminMain để đổi tên
                        // mainForm.UpdateSidebarName(UserSession.HoTen); 
                    }
                }
                else
                {
                    MessageBox.Show(res[1], "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                btnUpdateProf.Enabled = true;
            }
        }
    }
}
