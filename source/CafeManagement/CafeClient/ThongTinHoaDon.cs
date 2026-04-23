using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeCommon;

namespace CafeClient
{
    public partial class ThongTinHoaDon : UserControl
    {
        public event EventHandler OnEditRequested;
        public ThongTinHoaDon()
        {
            InitializeComponent();
        }

      
        public void UpdateCardData(Bill bill)
        {
            lblID.Text = $"#{bill.MaHD}";
            lblDate.Text = bill.NgayTao.ToString("dd/MM/yyyy - HH:mm");
            lblPrice.Text = $"{bill.ThanhTien:N0} đ";
            SetStatus(bill.TrangThai);
        }
        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
        private void ThongTinHoaDon_DoubleClick(object sender, EventArgs e)
        {
            // Trigger the event so the parent form (HoaDonAD) knows to open the popup
            OnEditRequested?.Invoke(this, EventArgs.Empty);
        }
        private void SetStatus(string status)
        {
            lblStatus.Text = status;

            switch (status)
            {
                case "Đã thanh toán":
                    lblStatus.BackColor = Color.FromArgb(232, 245, 233);
                    lblStatus.ForeColor = Color.DarkGreen;
                    break;
                case "Chưa thanh toán":
                    lblStatus.BackColor = Color.FromArgb(255, 235, 238);
                    lblStatus.ForeColor = Color.Red;
                    break;
                case "Đang xử lý":
                    lblStatus.BackColor = Color.FromArgb(255, 248, 225);
                    lblStatus.ForeColor = Color.DarkOrange;
                    break;
                default:
                    lblStatus.BackColor = Color.LightGray;
                    lblStatus.ForeColor = Color.Black;
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
