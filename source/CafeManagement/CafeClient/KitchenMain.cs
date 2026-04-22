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
    public partial class KitchenMain : Form
    {
        public KitchenMain()
        {
            InitializeComponent();

            pnlNav.Height = btnQlyOrder.Height;
            pnlNav.Top = btnQlyOrder.Top;
            pnlNav.Left = btnQlyOrder.Left;
            btnQlyOrder.BackColor = Color.FromArgb(128, 64, 0);

            this.PnlFormLoader.Controls.Clear();
            QuanLyOrder_BEP form = new QuanLyOrder_BEP() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();

            ThoiGian form123 = new ThoiGian() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel3.Controls.Clear();
            panel3.Controls.Add(form123);
            form123.Show();
        }

        private void btnQlyOrder_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnQlyOrder.Height;
            pnlNav.Top = btnQlyOrder.Top;
            btnQlyOrder.BackColor = Color.FromArgb(128, 64, 0);

            this.PnlFormLoader.Controls.Clear();
            QuanLyOrder_BEP form = new QuanLyOrder_BEP() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private void btnCTOrder_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCTOrder.Height;
            pnlNav.Top = btnCTOrder.Top;
            btnCTOrder.BackColor = Color.FromArgb(128, 64, 0);

            this.PnlFormLoader.Controls.Clear();
            ChiTietOrder_BEP form = new ChiTietOrder_BEP() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnThongKe.Height;
            pnlNav.Top = btnThongKe.Top;
            btnThongKe.BackColor = Color.FromArgb(128, 64, 0);

            this.PnlFormLoader.Controls.Clear();
            ThongKe_BEP form = new ThongKe_BEP() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnChat.Height;
            pnlNav.Top = btnChat.Top;
            btnChat.BackColor = Color.FromArgb(255, 128, 0);

            this.PnlFormLoader.Controls.Clear();
            Chat form = new Chat() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnTaiKhoan.Height;
            pnlNav.Top = btnTaiKhoan.Top;
            btnTaiKhoan.BackColor = Color.FromArgb(255, 128, 0);

            this.PnlFormLoader.Controls.Clear();
            TaiKhoan form = new TaiKhoan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnLogout.Height;
            pnlNav.Top = btnLogout.Top;
            btnLogout.BackColor = Color.FromArgb(255, 128, 0);


            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                // Gửi req lên Server để chuyển Offline
                string request = $"LOGOUT|{UserSession.MaNguoiDung}";
                await SocketClient.SendRequestAsync(request);


                UserSession.Clear();

                this.Hide();
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void btnQlyOrder_Leave(object sender, EventArgs e)
        {
            btnQlyOrder.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnCTOrder_Leave(object sender, EventArgs e)
        {
            btnCTOrder.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnThongKe_Leave(object sender, EventArgs e)
        {
            btnThongKe.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnChat_Leave(object sender, EventArgs e)
        {
            btnChat.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnTaiKhoan_Leave(object sender, EventArgs e)
        {
            btnTaiKhoan.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnLogout_Leave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KitchenMain_Load(object sender, EventArgs e)
        {
            AdminName.Text = UserSession.HoTen;
        }
    }
}
