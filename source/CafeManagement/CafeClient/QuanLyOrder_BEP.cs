using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeCommon;
using Newtonsoft.Json;

namespace CafeClient
{
    public partial class QuanLyOrder_BEP : Form
    {
        private List<BepOrderDTO> _danhSachGoc = new List<BepOrderDTO>();
        private List<string> _tatCaTenBan = new List<string>();
        private System.Windows.Forms.Timer _timerDemGio;

        public QuanLyOrder_BEP()
        {
            InitializeComponent();

            // ÉP LIÊN KẾT LẠI SỰ KIỆN CHỐNG LỖI DESIGNER BỊ MẤT KẾT NỐI SỰ KIỆN
            this.Load += QuanLyOrder_BEP_Load;
            btnLamMoi.Click += btnLamMoi_Click;
            this.FormClosed += QuanLyOrder_BEP_FormClosed;

            // KHỞI TẠO CẤU HÌNH LƯỚI THỦ CÔNG & KHÓA CHẶT MÀU SẮC CHỐNG TÀNG HÌNH CHỮ
            dgvOrders.Columns.Clear();
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.ReadOnly = true;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.RowTemplate.Height = 40;

            // Thiết lập bảng màu chuẩn mực (Nền trắng tinh, chữ đen đậm, khi chọn dòng đổi màu xanh da trời nhẹ)
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.DefaultCellStyle.BackColor = Color.White;
            dgvOrders.DefaultCellStyle.ForeColor = Color.Black;
            dgvOrders.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvOrders.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Định nghĩa kết cấu 7 cột hiển thị chuẩn
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaDonHang", DataPropertyName = "MaDonHang", HeaderText = "Mã Đơn", Width = 80 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenBan", DataPropertyName = "TenBan", HeaderText = "Tên Bàn", Width = 100 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThoiGianDat", DataPropertyName = "ThoiGianDat", HeaderText = "Thời Gian Đặt", Width = 100 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongMon", DataPropertyName = "SoLuongMon", HeaderText = "SL Món", Width = 80 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", DataPropertyName = "TrangThai", HeaderText = "Trạng Thái", Width = 140 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "UuTien", DataPropertyName = "UuTien", HeaderText = "Ưu Tiên", Width = 90 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThoiGianCho", HeaderText = "Thời Gian Chờ", Width = 160 });

            dgvOrders.CellFormatting += DgvOrders_CellFormatting;

            // Khởi tạo bộ đếm giờ cập nhật liên tục từng giây (1000ms)
            _timerDemGio = new System.Windows.Forms.Timer();
            _timerDemGio.Interval = 1000;
            _timerDemGio.Tick += (s, e) => {
                // Chỉ vẽ lại duy nhất cột thời gian chờ để tối ưu hiệu năng phần cứng, chống chớp lag màn hình
                if (!dgvOrders.IsDisposed && dgvOrders.Columns.Contains("ThoiGianCho"))
                {
                    dgvOrders.InvalidateColumn(dgvOrders.Columns["ThoiGianCho"].Index);
                }
            };
        }

        private void QuanLyOrder_BEP_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị các mục phân loại bộ lọc cố định
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Tất cả", "Chờ xác nhận", "Đang chế biến", "Hoàn thành", "Đã hủy" });
            cboTrangThai.SelectedIndex = 0;

            cboSapXep.Items.Clear();
            cboSapXep.Items.AddRange(new string[] { "Thời gian đặt (mới nhất xếp trước)", "Thời gian chờ (lâu nhất xếp trước)", "Ưu tiên" });
            cboSapXep.SelectedIndex = 0;

            cboTimBan.Items.Clear();
            cboTimBan.Items.Add("Tất cả");
            cboTimBan.SelectedIndex = 0;

            // Đăng ký các hàm kích hoạt khi người dùng thay đổi lựa chọn bộ lọc
            cboTrangThai.SelectedIndexChanged += BoLoc_ThayDoi;
            cboSapXep.SelectedIndexChanged += BoLoc_ThayDoi;
            cboTimBan.SelectedIndexChanged += BoLoc_ThayDoi;

            _timerDemGio.Start();
            TaiDuLieu();
        }

        private async void TaiDuLieu()
        {
            try
            {
                // 1. Gửi yêu cầu lấy TOÀN BỘ danh sách bàn ăn hiện hữu trong hệ thống cơ sở dữ liệu
                string tableJson = await SocketClient.SendRequestAsync("GET_ALL_TABLE_NAMES");
                if (!string.IsNullOrEmpty(tableJson) && tableJson.StartsWith("ALL_TABLE_NAMES_DATA|"))
                {
                    string tablesRaw = tableJson.Substring("ALL_TABLE_NAMES_DATA|".Length);
                    _tatCaTenBan = JsonConvert.DeserializeObject<List<string>>(tablesRaw) ?? new List<string>();
                }

                // 2. Gửi yêu cầu lấy danh sách các đơn hàng bếp hiện tại
                string orderJson = await SocketClient.SendRequestAsync("GET_BEP_ORDERS");
                if (!string.IsNullOrEmpty(orderJson) && orderJson.StartsWith("BEP_ORDERS_DATA|"))
                {
                    string dataRaw = orderJson.Substring("BEP_ORDERS_DATA|".Length);
                    _danhSachGoc = JsonConvert.DeserializeObject<List<BepOrderDTO>>(dataRaw) ?? new List<BepOrderDTO>();
                }

                // 3. Đổ dữ liệu đồng bộ lên ComboBox bàn ăn và Grid lưới
                CapNhatComboBan();
                ThucThiBoLocVaSapXep();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin từ Server: " + ex.Message);
            }
        }

        private void CapNhatComboBan()
        {
            string banCu = cboTimBan.SelectedItem?.ToString();

            cboTimBan.SelectedIndexChanged -= BoLoc_ThayDoi;
            cboTimBan.Items.Clear();
            cboTimBan.Items.Add("Tất cả");

            // NẠP TOÀN BỘ BÀN ĂN LẤY TỪ DB XUỐNG (Bàn trống cũng xuất hiện ở đây)
            foreach (var ban in _tatCaTenBan)
            {
                cboTimBan.Items.Add(ban);
            }

            if (!string.IsNullOrEmpty(banCu) && cboTimBan.Items.Contains(banCu))
                cboTimBan.SelectedItem = banCu;
            else
                cboTimBan.SelectedIndex = 0;

            cboTimBan.SelectedIndexChanged += BoLoc_ThayDoi;
        }

        private void BoLoc_ThayDoi(object sender, EventArgs e)
        {
            ThucThiBoLocVaSapXep();
        }

        private void ThucThiBoLocVaSapXep()
        {
            if (_danhSachGoc == null) return;

            var query = _danhSachGoc.AsEnumerable();

            // 1. Phân loại theo Trạng thái
            string tt = cboTrangThai.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(tt) && tt != "Tất cả")
            {
                // Chỉ lọc khi người dùng chọn đích danh một trạng thái cụ thể (VD: "Chờ xác nhận", "Đang chế biến", "Hoàn thành", "Đã hủy")
                query = query.Where(x => x.TrangThai == tt);
            }

            // 2. Phân loại theo Số Bàn Ăn
            string locBan = cboTimBan.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(locBan) && locBan != "Tất cả")
                query = query.Where(x => x.TenBan == locBan);

            // 3. Sắp xếp thứ tự
            string locSapXep = cboSapXep.SelectedItem?.ToString();
            if (locSapXep == "Thời gian chờ (lâu nhất xếp trước)")
                query = query.OrderBy(x => x.ThoiGianDat);
            else if (locSapXep == "Ưu tiên")
                query = query.OrderByDescending(x => x.UuTien).ThenBy(x => x.ThoiGianDat);
            else
                query = query.OrderByDescending(x => x.ThoiGianDat);

            dgvOrders.DataSource = null;
            dgvOrders.DataSource = query.ToList();
        }

        private void DgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvOrders.Rows.Count) return;
            var order = dgvOrders.Rows[e.RowIndex].DataBoundItem as BepOrderDTO;
            if (order == null) return;

            string colName = dgvOrders.Columns[e.ColumnIndex].Name;

            if (colName == "ThoiGianDat")
            {
                e.Value = order.ThoiGianDat.ToString("HH:mm:ss");
                e.FormattingApplied = true;
            }
            else if (colName == "TrangThai")
            {
                if (order.TrangThai == "Chờ xác nhận") e.CellStyle.ForeColor = Color.OrangeRed;
                else if (order.TrangThai == "Đang chế biến") e.CellStyle.ForeColor = Color.Blue;
                else if (order.TrangThai == "Hoàn thành") e.CellStyle.ForeColor = Color.Green;
                // Thêm đoạn này cho trạng thái hủy:
                else if (order.TrangThai == "Đã hủy")
                {
                    e.CellStyle.ForeColor = Color.Gray;
                    e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Strikeout); // Gạch ngang chữ
                }

                if (order.TrangThai != "Đã hủy")
                {
                    e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                }

                e.FormattingApplied = true;
            }
            else if (colName == "UuTien")
            {
                if (order.UuTien == 1)
                {
                    e.Value = "🔥 Gấp";
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                }
                else e.Value = "";
                e.FormattingApplied = true;
            }
            else if (colName == "ThoiGianCho")
            {
                // TÍNH TOÁN REALTIME TOÀN DIỆN: NGÀY - GIỜ - PHÚT - GIÂY
                TimeSpan ts = DateTime.Now - order.ThoiGianDat;

                if (ts.TotalSeconds < 0)
                {
                    e.Value = "0 giây";
                }
                else
                {
                    List<string> chuoiThoiGian = new List<string>();
                    if (ts.Days > 0) chuoiThoiGian.Add($"{ts.Days} ngày");
                    if (ts.Hours > 0) chuoiThoiGian.Add($"{ts.Hours} giờ");
                    if (ts.Minutes > 0) chuoiThoiGian.Add($"{ts.Minutes} phút");

                    // Luôn hiển thị đơn vị giây nếu đơn hàng ở mức giờ/phút hoặc vừa được đặt
                    if (ts.Days == 0) chuoiThoiGian.Add($"{ts.Seconds} giây");

                    e.Value = string.Join(" ", chuoiThoiGian);
                }

                // Ngưỡng bôi đỏ khẩn cấp nếu nhân viên bếp để đơn chờ vượt quá 15 phút
                if (ts.TotalMinutes >= 15)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.Font = dgvOrders.Font;
                }
                e.FormattingApplied = true;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void QuanLyOrder_BEP_FormClosed(object sender, FormClosedEventArgs e)
        {
            _timerDemGio?.Stop();
        }

        private void panel9_Paint(object sender, PaintEventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}