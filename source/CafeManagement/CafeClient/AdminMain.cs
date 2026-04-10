using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CafeCommon;

namespace CafeClient
{
    public partial class AdminMain : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );



        public AdminMain()
        {
            InitializeComponent();
            //this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDoanhThu.Height;
            pnlNav.Top = btnDoanhThu.Top;
            pnlNav.Left = btnDoanhThu.Left;
            btnDoanhThu.BackColor = Color.FromArgb(128, 64, 0);

            lblTitle.Text = "Doanh thu";
            this.PnlFormLoader.Controls.Clear();
            DoanhThu_AD formDoanhthu = new DoanhThu_AD() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(formDoanhthu);
            formDoanhthu.Show();

            ThoiGian form = new ThoiGian() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel3.Controls.Clear();
            panel3.Controls.Add(form);
            form.Show();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDoanhThu.Height;
            pnlNav.Top = btnDoanhThu.Top;
            pnlNav.Left = btnDoanhThu.Left;
            btnDoanhThu.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Doanh thu";
            this.PnlFormLoader.Controls.Clear();
            DoanhThu_AD formDoanhthu = new DoanhThu_AD() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(formDoanhthu);
            formDoanhthu.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnMenu.Height;
            pnlNav.Top = btnMenu.Top;
            btnMenu.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Menu";
            this.PnlFormLoader.Controls.Clear();
            Menu formMenu = new Menu() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(formMenu);
            formMenu.Show();
        }

        private void btnBanAn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnBanAn.Height;
            pnlNav.Top = btnBanAn.Top;
            btnBanAn.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Sơ đồ bàn ăn";
            this.PnlFormLoader.Controls.Clear();
            BanAn_AD formBanAn = new BanAn_AD() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(formBanAn);
            formBanAn.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnHoaDon.Height;
            pnlNav.Top = btnHoaDon.Top;
            btnHoaDon.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Hóa đơn";
            this.PnlFormLoader.Controls.Clear();
            HoaDon_AD formHoaDon = new HoaDon_AD() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(formHoaDon);
            formHoaDon.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnNhanVien.Height;
            pnlNav.Top = btnNhanVien.Top;
            btnNhanVien.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Nhân viên";
            this.PnlFormLoader.Controls.Clear();
            NhanVien_AD formNhanVien = new NhanVien_AD() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(formNhanVien);
            formNhanVien.Show();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnChat.Height;
            pnlNav.Top = btnChat.Top;
            btnChat.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Chat";
            this.PnlFormLoader.Controls.Clear();
            Chat formChat = new Chat() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(formChat);
            formChat.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnTaiKhoan.Height;
            pnlNav.Top = btnTaiKhoan.Top;
            btnTaiKhoan.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Tài khoản";
            this.PnlFormLoader.Controls.Clear();
            TaiKhoan formtaikhoan = new TaiKhoan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(formtaikhoan);
            formtaikhoan.Show();

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

                SocketClient.Disconnect(); //ngắt kết nối socket

                UserSession.Clear();

                this.Hide();
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void btnDoanhThu_Leave(object sender, EventArgs e)
        {
            btnDoanhThu.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnMenu_Leave(object sender, EventArgs e)
        {
            btnMenu.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnBanAn_Leave(object sender, EventArgs e)
        {
            btnBanAn.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnHoaDon_Leave(object sender, EventArgs e)
        {
            btnHoaDon.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnNhanVien_Leave(object sender, EventArgs e)
        {
            btnNhanVien.BackColor = Color.FromArgb(128, 64, 0);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminMain_Load(object sender, EventArgs e)
        {
            AdminName.Text = UserSession.HoTen;
        }

        
    }
}
