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
    public partial class WaiterMain : Form
    {
        public WaiterMain()
        {
            InitializeComponent();

            //this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnOrderVaBan.Height;
            pnlNav.Top = btnOrderVaBan.Top;
            pnlNav.Left = btnOrderVaBan.Left;
            btnOrderVaBan.BackColor = Color.FromArgb(128, 64, 0);

            lblTitle.Text = "Order và Bàn ăn";
            this.PnlFormLoader.Controls.Clear();
            Order_Ban form = new Order_Ban() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();

            ThoiGian form123123 = new ThoiGian() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel3.Controls.Clear();
            panel3.Controls.Add(form123123);
            form123123.Show();
        }

        private void btnOrderVaBan_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnOrderVaBan.Height;
            pnlNav.Top = btnOrderVaBan.Top;
            pnlNav.Left = btnOrderVaBan.Left;
            btnOrderVaBan.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Order và Bàn ăn";
            this.PnlFormLoader.Controls.Clear();
            Order_Ban form = new Order_Ban() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnThanhToan.Height;
            pnlNav.Top = btnThanhToan.Top;
            btnThanhToan.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Thanh toán";
            this.PnlFormLoader.Controls.Clear();
            ThanhToan_PV form = new ThanhToan_PV() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private void btnTheoDoiDH_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnTheoDoiDH.Height;
            pnlNav.Top = btnTheoDoiDH.Top;
            btnTheoDoiDH.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Theo dõi đơn hàng";
            this.PnlFormLoader.Controls.Clear();
            TheoDoiOrder_PV form = new TheoDoiOrder_PV() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnChat.Height;
            pnlNav.Top = btnChat.Top;
            btnChat.BackColor = Color.FromArgb(255, 128, 0);

            lblTitle.Text = "Chat";
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

            lblTitle.Text = "Tài khoản";
            this.PnlFormLoader.Controls.Clear();
            TaiKhoan form = new TaiKhoan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlFormLoader.Controls.Add(form);
            form.Show();
        }



        private void btnLogout_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnLogout.Height;
            pnlNav.Top = btnLogout.Top;
            btnLogout.BackColor = Color.FromArgb(255, 128, 0);


            Login form = new Login();
            this.Hide();
            form.Show();
        }

        private void btnOrderVaBan_Leave(object sender, EventArgs e)
        {
            btnOrderVaBan.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnThanhToan_Leave(object sender, EventArgs e)
        {
            btnThanhToan.BackColor = Color.FromArgb(128, 64, 0);
        }

        private void btnTheoDoiDH_Leave(object sender, EventArgs e)
        {
            btnTheoDoiDH.BackColor = Color.FromArgb(128, 64, 0);
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
    }
}
