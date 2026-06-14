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

            // ĐỊNH NGHĨA ÁNH XẠ CHÍNH XÁC VÀO CÁC CỘT TĨNH DESIGNER CỦA BẠN:
            dgvHoaDon.AutoGenerateColumns = false;
            colMaHD.DataPropertyName = "MaHD";
            colMaBanAn.DataPropertyName = "TenBan"; // Đọc thẳng trường chữ "TenBan" xử lý từ Server gửi sang
            colTongTien.DataPropertyName = "TongTien";
            colNgayTao.DataPropertyName = "NgayTao";

            // Map status column (added in designer dynamically)
            if (dgvHoaDon.Columns.Contains("colTrangThai"))
            {
                dgvHoaDon.Columns["colTrangThai"].DataPropertyName = "TrangThai";
                dgvHoaDon.Columns["colTrangThai"].HeaderText = "Trạng Thái";
            }
            colTongTien.DefaultCellStyle.Format = "N0";

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
                    // payload after prefix
                    var payload = res.Substring(8);

                    // Deserialize into DataTable so DataGridView can bind to named columns (MaHD, TenBan, TongTien, NgayTao)
                    System.Data.DataTable table = null;
                    try
                    {
                        table = JsonConvert.DeserializeObject<System.Data.DataTable>(payload);
                    }
                    catch
                    {
                        // fallback: try parse to list of HoaDon then convert
                        try
                        {
                            var list = JsonConvert.DeserializeObject<List<HoaDon>>(payload);
                            table = new System.Data.DataTable();
                            if (list != null && list.Count > 0)
                            {
                                // create columns from properties we need
                                table.Columns.Add("MaHD", typeof(int));
                                table.Columns.Add("TenBan", typeof(string));
                                table.Columns.Add("TongTien", typeof(decimal));
                                table.Columns.Add("NgayTao", typeof(string));
                                table.Columns.Add("TrangThai", typeof(string));
                                table.Columns.Add("MaBan", typeof(int));
                                table.Columns.Add("MaKH", typeof(int));

                                foreach (var it in list)
                                {
                                    table.Rows.Add(it.MaHD, it.TenBan, it.TongTien, it.NgayTao.ToString("dd/MM/yyyy"), it.TrangThai, it.MaBanAn ?? 0, it.MaKH ?? 0);
                                }
                            }
                        }
                        catch { }
                    }

                    if (table != null)
                    {
                        dgvHoaDon.DataSource = null;
                        dgvHoaDon.DataSource = table;
                        dgvHoaDon.Refresh();

                        dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvHoaDon.DefaultCellStyle.ForeColor = Color.Black;
                        // No debug dialogs: table populated
                    }
                    else
                    {
                        MessageBox.Show("DEBUG: Failed to parse GET_ALL_BILLS payload:\n" + payload, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
                try
                {
                    var table = JsonConvert.DeserializeObject<System.Data.DataTable>(res);
                    dgvHoaDon.DataSource = table;
                }
                catch
                {
                    // fallback to attempt parsing as list of HoaDon
                    dgvHoaDon.DataSource = JsonConvert.DeserializeObject<List<HoaDon>>(res);
                }
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
                if (res.Contains("SUCCESS|"))
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
            // 1. Kiểm tra các điều kiện đầu vào cơ bản có sẵn
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

            // --- BẮT ĐẦU YÊU CẦU 2: HIỂN THỊ HỘP THOẠI XÁC NHẬN CHI TIẾT ---
            decimal tongTienGoc = selectedBill.TongTien;
            decimal giamDiem = 0;
            if (cbDiemTichLuy.SelectedIndex == 1 && currentCustomer != null)
            {
                giamDiem = (decimal)currentCustomer.DiemTichLuy * 1000;
            }

            string maGiamGiaDaDung = string.IsNullOrEmpty(tbMaGiamGia.Text.Trim()) ? "Không sử dụng" : tbMaGiamGia.Text.Trim();
            string hinhThucThanhToan = chkChuyenKhoan.Checked ? "Chuyển khoản" : "Tiền mặt";
            string loaiKhachHang = (currentCustomer != null) ? $"{currentCustomer.TenKH} (Thành viên)" : "Khách vãng lai";

            // Xây dựng chuỗi nội dung thông báo tóm tắt đơn hàng
            StringBuilder confirmMsg = new StringBuilder();
            confirmMsg.AppendLine("=== THÔNG TIN XÁC NHẬN THANH TOÁN ===");
            confirmMsg.AppendLine($"Khách hàng: {loaiKhachHang}");
            confirmMsg.AppendLine($"Tổng tiền hóa đơn: {tongTienGoc.ToString("N0")} đ");
            if (giamDiem > 0)
            {
                confirmMsg.AppendLine($"- Giảm trừ điểm tích lũy: {giamDiem.ToString("N0")} đ ({currentCustomer.DiemTichLuy} điểm)");
            }
            if (maGiamGiaDaDung != "Không sử dụng")
            {
                confirmMsg.AppendLine($"- Mã giảm giá áp dụng: {maGiamGiaDaDung}");
            }
            confirmMsg.AppendLine("------------------------------------");
            confirmMsg.AppendLine($"THÀNH TIỀN CUỐI CÙNG: {finalThanhTien.ToString("N0")} đ");
            confirmMsg.AppendLine($"Hình thức: {hinhThucThanhToan}");
            confirmMsg.AppendLine("\nBạn có chắc chắn muốn tiến hành xác nhận thanh toán hóa đơn này không?");

            // Hiển thị MessageBox xác nhận Yes/No
            DialogResult dialogResult = MessageBox.Show(confirmMsg.ToString(), "Xác nhận thanh toán đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu chọn No thì hủy bỏ hành động, quay lại màn hình
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            // --- KẾT THÚC YÊU CẦU 2 ---


            // --- BẮT ĐẦU YÊU CẦU 1: XỬ LÝ THÔNG TIN KHÁCH HÀNG THÀNH VIÊN ---
            string maKH = currentCustomer != null ? currentCustomer.MaKH.ToString() : "";
            string tenKH = "";
            string sdtKH = "";

            // Nếu không phải khách vãng lai (có dữ liệu currentCustomer hợp lệ)
            if (currentCustomer != null && txtTenKH.Text != "Khách vãng lai")
            {
                tenKH = currentCustomer.TenKH;
                sdtKH = textBox4.Text.Trim(); // Lấy từ ô tìm kiếm số điện thoại của bạn
            }
            // --- KẾT THÚC YÊU CẦU 1 ---


            float diemDaDung = 0f;
            if (cbDiemTichLuy.SelectedIndex == 1 && currentCustomer != null)
            {
                diemDaDung = currentCustomer.DiemTichLuy;
            }

            // Định dạng số liệu sang chuỗi InvariantCulture để tránh xung đột hệ thống dấu chấm/phẩy
            string soTienGui = finalThanhTien.ToString("F1", System.Globalization.CultureInfo.InvariantCulture);
            string stringDiemDung = diemDaDung.ToString("F1", System.Globalization.CultureInfo.InvariantCulture);

            // Gửi thêm thông tin tên và SĐT qua chuỗi Request lên Server (bổ sung tham số vào cuối giao thức cũ)
            // Cấu trúc chuỗi mới: CONFIRM_PAYMENT|MaHD|MaBanAn|MaKH|SoTien|HinhThuc|DiemDung|TenKH|SdtKH
            string req = $"CONFIRM_PAYMENT|{selectedBill.MaHD}|{selectedBill.MaBanAn}|{maKH}|{soTienGui}|{hinhThucThanhToan}|{stringDiemDung}|{tenKH}|{sdtKH}";
            string res = await SocketClient.SendRequestAsync(req);

            if (res.Contains("PAYMENT_SUCCESS"))
            {
                MessageBox.Show("Thanh toán hoàn tất và hóa đơn đã được cập nhật thành 'Đã thanh toán'!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật điểm tích lũy trên giao diện nếu có dùng
                if (diemDaDung > 0)
                {
                    txtDiemTichLuy.Text = "0.0";
                    if (currentCustomer != null) currentCustomer.DiemTichLuy = 0f;
                }

                // Xóa sạch dữ liệu cũ trên các ô TextBox để sẵn sàng nhận đơn mới
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

                // Làm mới lại danh sách hóa đơn trên màn hình hiển thị
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

            // DataBoundItem can be dynamic, HoaDon or DataRowView depending on how we bound the grid.
            var dataItem = dgvHoaDon.Rows[e.RowIndex].DataBoundItem;
            if (dataItem != null)
            {
                int mahd = 0;
                decimal tong = 0;
                string trangthai = "Chưa thanh toán";
                object mahkObj = null;
                int maBan = 0;
                string tenBanStr = "";
                string ngayTaoStr = "";
                string tenKHDaLuu = "";

                if (dataItem is System.Data.DataRowView drv)
                {
                    var row = drv.Row;
                    mahd = row.Table.Columns.Contains("MaHD") && row["MaHD"] != DBNull.Value ? Convert.ToInt32(row["MaHD"]) : 0;
                    tong = row.Table.Columns.Contains("TongTien") && row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : 0;
                    trangthai = row.Table.Columns.Contains("TrangThai") && row["TrangThai"] != DBNull.Value ? row["TrangThai"].ToString() : trangthai;
                    mahkObj = row.Table.Columns.Contains("MaKH") ? row["MaKH"] : null;
                    tenBanStr = row.Table.Columns.Contains("TenBan") && row["TenBan"] != DBNull.Value ? row["TenBan"].ToString() : "";
                    ngayTaoStr = row.Table.Columns.Contains("NgayTao") && row["NgayTao"] != DBNull.Value ? row["NgayTao"].ToString() : "";
                    tenKHDaLuu = row.Table.Columns.Contains("TenKH") && row["TenKH"] != DBNull.Value ? row["TenKH"].ToString() : "";
                    maBan = row.Table.Columns.Contains("MaBan") && row["MaBan"] != DBNull.Value ? Convert.ToInt32(row["MaBan"]) : 0;
                }
                else
                {
                    // Fallback for dynamic / typed objects
                    try { mahd = Convert.ToInt32(dataItem.GetType().GetProperty("MaHD")?.GetValue(dataItem)); } catch { }
                    try { tong = Convert.ToDecimal(dataItem.GetType().GetProperty("TongTien")?.GetValue(dataItem)); } catch { }
                    try { trangthai = dataItem.GetType().GetProperty("TrangThai")?.GetValue(dataItem)?.ToString() ?? trangthai; } catch { }
                    try { mahkObj = dataItem.GetType().GetProperty("MaKH")?.GetValue(dataItem); } catch { }
                    try { tenBanStr = dataItem.GetType().GetProperty("TenBan")?.GetValue(dataItem)?.ToString() ?? ""; } catch { }
                    try { ngayTaoStr = dataItem.GetType().GetProperty("NgayTao")?.GetValue(dataItem)?.ToString() ?? ""; } catch { }
                    try { tenKHDaLuu = dataItem.GetType().GetProperty("TenKH")?.GetValue(dataItem)?.ToString() ?? ""; } catch { }
                    try { maBan = Convert.ToInt32(dataItem.GetType().GetProperty("MaBan")?.GetValue(dataItem) ?? 0); } catch { maBan = 0; }
                }

                selectedBill = new HoaDon
                {
                    MaHD = mahd,
                    TongTien = tong,
                    TrangThai = trangthai,
                    TenKH = tenKHDaLuu,
                    MaBanAn = maBan > 0 ? (int?)maBan : null
                };

                txtMaHD.Text = selectedBill.MaHD.ToString();
                txtMaBanAn.Text = tenBanStr; // TenBan is already a display string like "Bàn 1" or "Mang về"
                txtTongTien.Text = selectedBill.TongTien.ToString("N0");
                txtNgayXuatHD.Text = ngayTaoStr;

                txtTenKH.Text = "Đang tìm...";

                if (mahkObj != null && mahkObj != DBNull.Value && int.TryParse(mahkObj.ToString(), out int makh) && makh > 0)
                {
                    selectedBill.MaKH = makh;
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
                    if (!string.IsNullOrEmpty(selectedBill.TenKH))
                    {
                        txtTenKH.Text = selectedBill.TenKH;
                    }
                    else
                    {
                        txtTenKH.Text = "Khách vãng lai";
                    }
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
