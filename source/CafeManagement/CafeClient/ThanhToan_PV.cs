using CafeCommon;
using Newtonsoft.Json;
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
    public partial class ThanhToan_PV : Form
    {
        public ThanhToan_PV()
        {
            InitializeComponent();
            LoadDSHoaDon();

        }

        private KhachHang currentCustomer = null;
        private HoaDon selectedBill = null;


        // 1. Lấy danh sách hóa đơn hiện lên bảng bên phải
        private async void LoadDSHoaDon()
        {
            string res = await SocketClient.SendRequestAsync("GET_ALL_BILLS");
            if (res.StartsWith("SUCCESS|"))
            {
                var data = JsonConvert.DeserializeObject<List<HoaDon>>(res.Substring(8));
                dgvHoaDon.DataSource = data;
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkChuyenKhoan_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkChuyenKhoan.Checked)
            {
                picQR.Visible = true;
                // Tạo nội dung mã QR (VietQR format đơn giản)
                string qrContent = $"Pay HD{txtMaHD.Text} Amount {txtThanhTien.Text}";
                using (var qrGen = new QRCoder.QRCodeGenerator())
                {
                    var data = qrGen.CreateQrCode(qrContent, QRCoder.QRCodeGenerator.ECCLevel.Q);
                    var qr = new QRCoder.QRCode(data);
                    picQR.Image = qr.GetGraphic(10);
                }
            }
            else { picQR.Visible = false; }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = tbTimKiem.Text;
            // Gọi lệnh SEARCH_BILL lên server
            string res = await SocketClient.SendRequestAsync("SEARCH_BILL_BY_ID|" + keyword);
            // Cập nhật lại dgvHoaDon
            if (!res.StartsWith("ERROR"))
            {
                dgvHoaDon.DataSource = JsonConvert.DeserializeObject<List<HoaDon>>(res);
            }
        }

        private void btnTinhThanhTien_Click(object sender, EventArgs e)
        {
            if (selectedBill == null) return;
            decimal tong = selectedBill.TongTien;
            decimal giam = 0;

            // Nếu chọn "Sử dụng điểm" (giả sử index 1)
            if (cbDiemTichLuy.SelectedIndex == 1 && currentCustomer != null)
            {
                giam = currentCustomer.DiemTichLuy * 1000; // 1 điểm = 1000đ
            }

            decimal thanhTien = tong - giam;
            txtThanhTien.Text = (thanhTien > 0 ? thanhTien : 0).ToString("N0");
        }

        private async void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedBill == null) return;
            string maKH = currentCustomer != null ? currentCustomer.MaKH.ToString() : "";
            string hinhThuc = chkChuyenKhoan.Checked ? "Chuyển khoản" : "Tiền mặt";

            string req = $"CONFIRM_PAYMENT|{selectedBill.MaHD}|{selectedBill.MaBanAn}|{maKH}|{txtThanhTien.Text}|{hinhThuc}";
            string res = await SocketClient.SendRequestAsync(req);

            if (res == "PAYMENT_SUCCESS")
            {
                MessageBox.Show("Thanh toán hoàn tất!");
                LoadDSHoaDon(); // Refresh lại danh sách
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedBill = dgvHoaDon.Rows[e.RowIndex].DataBoundItem as HoaDon;
            if (selectedBill != null)
            {
                txtMaHD.Text = selectedBill.MaHD.ToString();
                txtMaBanAn.Text = selectedBill.MaBanAn.ToString();
                txtTongTien.Text = selectedBill.TongTien.ToString("N0");
                txtNgayXuatHD.Text = selectedBill.NgayTao.ToString("dd/MM/yyyy");
                // Reset thông tin khách hàng khi chọn hóa đơn mới
                txtTenKH.Text = "";
                txtDiemTichLuy.Text = "0";
                currentCustomer = null;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDSHoaDon();
            txtMaHD.Clear();
            txtThanhTien.Clear();
            picQR.Image = null;
        }

        private async void btnTimKH_Click(object sender, EventArgs e)
        {
            string sdt = textBox4.Text;
            // Gọi lệnh GET_CUSTOMER_BY_PHONE lên server
            string res = await SocketClient.SendRequestAsync("GET_CUSTOMER_BY_PHONE|" + sdt);

            if (res.StartsWith("SUCCESS|"))
            {
                currentCustomer = JsonConvert.DeserializeObject<KhachHang>(res.Substring(8));
                txtTenKH.Text = currentCustomer.TenKH;
                txtDiemTichLuy.Text = currentCustomer.DiemTichLuy.ToString();
            }
            else
            {
                MessageBox.Show("Khách hàng chưa đăng ký thành viên!");
            }
        }


    }
}
