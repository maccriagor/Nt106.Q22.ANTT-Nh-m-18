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
    public partial class ThongTinHoaDon : UserControl
    {
        public ThongTinHoaDon()
        {
            InitializeComponent();
        }
        public HoaDon currentBill;
        public event EventHandler OnCardClicked;
        public ThongTinHoaDon(HoaDon bill)
        {
            InitializeComponent();
            this.currentBill = bill;

            // Display the 4 required pieces of info
            txtMaHD.Text = "Mã HD: " + bill.MaHD;
            txtMaNV.Text = "NV: " + bill.MaNV;
            txtMaBanAn.Text = "Bàn: " + bill.MaBanAn;
            txtNgayXuat.Text = bill.NgayTao.ToString("dd/MM/yyyy");

            // Trigger the event when the card (or any label inside) is clicked
            this.Click += (s, e) => OnCardClicked?.Invoke(this, EventArgs.Empty);
            foreach (Control c in this.Controls)
            {
                c.Click += (s, e) => OnCardClicked?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
