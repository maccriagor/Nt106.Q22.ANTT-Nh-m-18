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
            picQR.SizeMode = PictureBoxSizeMode.Zoom;

            picQR.Click += picQR_Click;
            btnThanhToan.Enabled = false;
            LoadDSHoaDon();

        }

        private KhachHang currentCustomer = null;
        private HoaDon selectedBill = null;
        private decimal finalThanhTien = 0;


        // 1. Lấy danh sách hóa đơn hiện lên bảng bên phải
        private async void LoadDSHoaDon()
        {
            try
            {
                string res = await SocketClient.SendRequestAsync("GET_ALL_BILLS");
                if (res.StartsWith("SUCCESS|"))
                {
                    var data = JsonConvert.DeserializeObject<List<HoaDon>>(res.Substring(8));

                    dgvHoaDon.DataSource = null;
                    dgvHoaDon.Columns.Clear();
                    dgvHoaDon.AutoGenerateColumns = false;

                    dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaHD", HeaderText = "Mã HĐ", Name = "MaHD" });
                    dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaBanAn", HeaderText = "Bàn", Name = "MaBanAn" });
                    dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TongTien", HeaderText = "Tổng Tiền", Name = "TongTien" });
                    dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayTao", HeaderText = "Ngày Tạo", Name = "NgayTao" });
                    dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Trạng Thái", Name = "TrangThai" });

                    dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";

                    dgvHoaDon.DataSource = data;
                    dgvHoaDon.Refresh();

                    dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvHoaDon.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị bảng: " + ex.Message);
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkChuyenKhoan_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkChuyenKhoan.Checked)
            {
                checkBox1.Checked = false;

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

        private async void btnTinhThanhTien_Click(object sender, EventArgs e)
        {
            if (selectedBill == null) return;
            decimal tong = selectedBill.TongTien;
            decimal giamDiem = 0;
            decimal giamVoucher = 0;

            // 1. Giảm giá theo điểm tích lũy
            if (cbDiemTichLuy.SelectedIndex == 1 && currentCustomer != null)
            {
                giamDiem = (decimal)currentCustomer.DiemTichLuy * 1000;
            }

            // 2. Kiểm tra và giảm giá theo Mã Khuyến Mãi (LoaiKM)
            if (!string.IsNullOrEmpty(tbMaGiamGia.Text.Trim()))
            {
                string res = await SocketClient.SendRequestAsync("GET_DISCOUNT_BY_CODE|" + tbMaGiamGia.Text.Trim());
                if (res.StartsWith("SUCCESS|"))
                {
                    var km = JsonConvert.DeserializeObject<KhuyenMai>(res.Substring(8));
                    if (km != null)
                    {
                        // Phân loại hình thức giảm giá từ cột loaikm trong DB
                        if (km.LoaiKM == "Phần trăm")
                        {
                            giamVoucher = tong * (km.GiaTriGiam / 100);
                        }
                        else if (km.LoaiKM == "Số tiền")
                        {
                            giamVoucher = km.GiaTriGiam;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã giảm giá không hợp lệ hoặc đã hết hạn dùng!");
                    tbMaGiamGia.Clear();
                }
            }

            // 3. Tính thành tiền cuối cùng
            finalThanhTien = tong - giamDiem - giamVoucher;
            if (finalThanhTien < 0) finalThanhTien = 0;

            // Hiển thị lên giao diện dạng số lẻ
            txtThanhTien.Text = finalThanhTien.ToString("N1");

            // Cập nhật QR nếu chọn chuyển khoản
            if (chkChuyenKhoan.Checked)
            {
                string qrContent = $"Pay HD{txtMaHD.Text} Amount {finalThanhTien.ToString("F1", System.Globalization.CultureInfo.InvariantCulture)}";
                using (var qrGen = new QRCoder.QRCodeGenerator())
                {
                    var data = qrGen.CreateQrCode(qrContent, QRCoder.QRCodeGenerator.ECCLevel.Q);
                    var qr = new QRCoder.QRCode(data);
                    picQR.Image = qr.GetGraphic(10);
                }
            }
        }

        private async void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedBill == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn từ danh sách để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedBill.TrangThai != "Chưa thanh toán")
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán trước đó!", "Cảnh báo");
                return;
            }

            if (string.IsNullOrEmpty(txtThanhTien.Text))
            {
                MessageBox.Show("Vui lòng nhấn nút 'Tính thành tiền' trước khi xác nhận thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = currentCustomer != null ? currentCustomer.MaKH.ToString() : "";
            string hinhThuc = chkChuyenKhoan.Checked ? "Chuyển khoản" : "Tiền mặt";

            float diemDaDung = 0f;
            if (cbDiemTichLuy.SelectedIndex == 1 && currentCustomer != null)
            {
                diemDaDung = currentCustomer.DiemTichLuy;
            }

            // Định dạng số liệu sang chuỗi InvariantCulture để tránh xung đột định dạng dấu chấm/phẩy trên Server
            string soTienGui = finalThanhTien.ToString("F1", System.Globalization.CultureInfo.InvariantCulture);
            string stringDiemDung = diemDaDung.ToString("F1", System.Globalization.CultureInfo.InvariantCulture);

            // 4. Gửi yêu cầu CONFIRM_PAYMENT lên Server
            string req = $"CONFIRM_PAYMENT|{selectedBill.MaHD}|{selectedBill.MaBanAn}|{maKH}|{soTienGui}|{hinhThuc}|{stringDiemDung}";
            string res = await SocketClient.SendRequestAsync(req);

            if (res == "PAYMENT_SUCCESS")
            {
                MessageBox.Show("Thanh toán hoàn tất và hóa đơn đã được cập nhật thành 'Đã thanh toán'!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật điểm tích lũy trên giao diện nếu có dùng
                if (diemDaDung > 0)
                {
                    txtDiemTichLuy.Text = "0.0";
                    if (currentCustomer != null) currentCustomer.DiemTichLuy = 0f;
                }

                // 5. Xóa sạch dữ liệu cũ trên các ô TextBox để sẵn sàng nhận đơn mới
                txtMaHD.Clear();
                txtMaBanAn.Clear();
                txtTongTien.Clear();
                txtNgayXuatHD.Clear();
                txtTenKH.Clear();
                txtDiemTichLuy.Clear();
                txtThanhTien.Clear();
                if (tbMaGiamGia != null) tbMaGiamGia.Clear();
                picQR.Image = null;

                // Hủy liên kết biến tạm để tránh nhấn nút Pay lại đơn cũ
                selectedBill = null;
                currentCustomer = null;
                finalThanhTien = 0;

                chkChuyenKhoan.Checked = false;
                checkBox1.Checked = false;
                btnThanhToan.Enabled = false;

                // 6. Làm mới lại danh sách hóa đơn trên màn hình hiển thị
                LoadDSHoaDon();
            }
            else
            {
                MessageBox.Show("Gặp lỗi trong quá trình xử lý thanh toán trên hệ thống Server: " + res, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDSHoaDon();
            txtMaHD.Clear();
            txtMaBanAn.Clear();
            txtTongTien.Clear();
            txtNgayXuatHD.Clear();
            txtTenKH.Clear();
            txtDiemTichLuy.Clear();
            txtThanhTien.Clear();
            picQR.Image = null;
            selectedBill = null;
            currentCustomer = null;
            finalThanhTien = 0;
            btnThanhToan.Enabled = false;
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
                txtDiemTichLuy.Text = currentCustomer.DiemTichLuy.ToString("N1");

            }
            else
            {
                MessageBox.Show("Khách hàng chưa đăng ký thành viên!");
            }
        }

        private async void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selectedBill = dgvHoaDon.Rows[e.RowIndex].DataBoundItem as HoaDon;

            if (selectedBill != null)
            {
                txtMaHD.Text = selectedBill.MaHD.ToString();
                txtMaBanAn.Text = selectedBill.MaBanAn?.ToString() ?? "Mang về";
                txtTongTien.Text = selectedBill.TongTien.ToString("N0");
                txtNgayXuatHD.Text = selectedBill.NgayTao.ToString("dd/MM/yyyy");

                txtTenKH.Text = "Đang tìm...";

                if (selectedBill.MaKH.HasValue && selectedBill.MaKH > 0)
                {
                    string res = await SocketClient.SendRequestAsync($"GET_CUSTOMER_BY_ID|{selectedBill.MaKH}");

                    if (res.StartsWith("SUCCESS|"))
                    {
                        currentCustomer = JsonConvert.DeserializeObject<KhachHang>(res.Substring(8));
                        txtTenKH.Text = currentCustomer.TenKH;
                        txtDiemTichLuy.Text = currentCustomer.DiemTichLuy.ToString("N1");
                    }
                    else
                    {
                        txtTenKH.Text = "Không tìm thấy khách";
                        txtDiemTichLuy.Text = "0";
                    }
                }
                else
                {
                    txtTenKH.Text = "Khách vãng lai";
                    txtDiemTichLuy.Text = "0";
                    currentCustomer = null;
                }
                chkChuyenKhoan.Checked = false;
                checkBox1.Checked = false;
                btnThanhToan.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Tự động bỏ chọn Chuyển khoản khi chọn Tiền mặt
                chkChuyenKhoan.Checked = false;
                picQR.Visible = false; // Ẩn QR đi vì đang trả tiền mặt
                btnThanhToan.Enabled = true;
            }
            else
            {
                if (!chkChuyenKhoan.Checked) btnThanhToan.Enabled = false;
            }
        }

        private void picQR_Click(object sender, EventArgs e)
        {
            if (chkChuyenKhoan.Checked && finalThanhTien > 0)
            {
                MessageBox.Show($"[VietQR Hệ Thống]\nTài khoản cửa hàng đã NHẬN THÀNH CÔNG số tiền {finalThanhTien.ToString("N1")}đ từ khách hàng!",
                                "Thông báo kết nối Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnThanhToan.Enabled = true; // <-- MỞ KHÓA NÚT THANH TOÁN
            }
        }
    }
}
