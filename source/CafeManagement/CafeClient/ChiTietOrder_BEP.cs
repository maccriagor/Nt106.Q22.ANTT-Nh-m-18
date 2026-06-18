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
    public partial class ChiTietOrder_BEP : Form
    {
        // Lưu trữ danh sách món ăn hiện tại trên lưới
        private List<ChiTietOrderDTO> _currentKitchenItems = new List<ChiTietOrderDTO>();
        // Lưu trữ dòng đang được chọn
        private ChiTietOrderDTO _selectedItem = null;

        public ChiTietOrder_BEP()
        {
            InitializeComponent();
        }

        private async void ChiTietOrder_BEP_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            InitStaticComboBoxes();

            // Tải dữ liệu từ Server
            await LoadKitchenStaff();
            await LoadKitchenItems();

            // Xóa rỗng và khóa Form bên trái
            ClearLeftPanel();

            // [THÊM DÒNG NÀY]: Gắn "tai nghe" cho Form Bếp
            SocketClient.OnMessageReceived += SocketClient_OnMessageReceived;
        }

        // Cấu hình cột cho DataGridView (bên phải)
        private void SetupDataGridView()
        {
            dgvDonHang.AutoGenerateColumns = false;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.MultiSelect = false;
            dgvDonHang.ReadOnly = true;

            dgvDonHang.Columns.Clear();
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenMon", HeaderText = "Tên món", Width = 150 });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenBan", HeaderText = "Bàn", Width = 80 });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "SL", Width = 50 });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenTrangThai", HeaderText = "Trạng thái", Width = 120 });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GioDatMon", HeaderText = "Giờ đặt", Width = 80 });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThoiGianDuKien", HeaderText = "Dự kiến (p)", Width = 90 });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LoaiUuTien", HeaderText = "Ưu tiên", Width = 100 });
        }

        // Khởi tạo các ComboBox cố định (Trạng thái)
        private void InitStaticComboBoxes()
        {
            // Trạng thái cho Bếp chỉ có 3 mức tương tác chính
            var trangThaiList = new List<dynamic>
            {
                new { Ma = 0, Ten = "0 - Chờ xác nhận" },
                new { Ma = 1, Ten = "1 - Đang làm" },
                new { Ma = 2, Ten = "2 - Hoàn thành" }
            };
            cbTrangThai.DataSource = trangThaiList;
            cbTrangThai.DisplayMember = "Ten";
            cbTrangThai.ValueMember = "Ma";

            // Khóa các ComboBox chỉ dùng để hiển thị (Read-only)
            cbUuTien.Enabled = false;
            cbTenMon.Enabled = false;
            cbTenBan.Enabled = false;
            tbMaDonHang.ReadOnly = true;
        }

        private async Task LoadKitchenStaff()
        {
            string res = await SocketClient.SendRequestAsync("GET_KITCHEN_STAFF");
            if (res.StartsWith("SUCCESS"))
            {
                string json = res.Split('|')[1];
                var staffList = JsonConvert.DeserializeObject<List<UserAccount>>(json) ?? new List<UserAccount>();

                // Đổ vào ComboBox Đầu bếp
                cbDauBep.DataSource = staffList;
                cbDauBep.DisplayMember = "HoTen";
                cbDauBep.ValueMember = "MaNguoiDung";
                cbDauBep.SelectedIndex = -1; // Mặc định không chọn ai
            }
        }

        private async Task LoadKitchenItems()
        {
            string res = await SocketClient.SendRequestAsync("GET_KITCHEN_ITEMS");
            if (res.StartsWith("SUCCESS"))
            {
                string json = res.Split('|')[1];

                // Cấu hình an toàn cho ngày tháng
                var settings = new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-ddTHH:mm:ss",
                    Culture = new System.Globalization.CultureInfo("vi-VN"),
                    Error = (sender, args) => { args.ErrorContext.Handled = true; }
                };

                _currentKitchenItems = JsonConvert.DeserializeObject<List<ChiTietOrderDTO>>(json, settings) ?? new List<ChiTietOrderDTO>();

                // Đổ dữ liệu lên lưới DataGridView
                dgvDonHang.DataSource = null;
                dgvDonHang.DataSource = _currentKitchenItems;
            }
            else
            {
                _currentKitchenItems.Clear();
                dgvDonHang.DataSource = null;
            }
        }

        private void ClearLeftPanel()
        {
            _selectedItem = null;

            lb_TenNV.Text = "---";
            tbMaDonHang.Text = "";
            cbTrangThai.SelectedIndex = -1;
            cbUuTien.Text = "";
            cbDauBep.SelectedIndex = -1;
            cbTenMon.Text = "";
            cbTenBan.Text = "";
            txtThoiGianDuKien.Text = "";
            txtGhiChuBep.Text = ""; // Giả sử tên textbox Ghi chú của bạn là txtGhiChuBep

            btnCapNhat.Enabled = false;
            btnHuyMon.Enabled = false;
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _currentKitchenItems.Count)
            {
                // Lấy đối tượng đang được click
                _selectedItem = _currentKitchenItems[e.RowIndex];

                // Đổ dữ liệu lên UI
                lb_TenNV.Text = _selectedItem.TenNVOrder;
                tbMaDonHang.Text = _selectedItem.MaDonHang.ToString();
                cbTrangThai.SelectedValue = _selectedItem.TrangThaiItem;
                cbUuTien.Text = _selectedItem.LoaiUuTien;

                // Set Đầu bếp: Nếu Null thì để rỗng, nếu có ID thì auto chọn tên người đó
                if (_selectedItem.MaNhanVienCheBien.HasValue)
                    cbDauBep.SelectedValue = _selectedItem.MaNhanVienCheBien.Value;
                else
                    cbDauBep.SelectedIndex = -1;

                cbTenMon.Text = _selectedItem.TenMon;
                cbTenBan.Text = _selectedItem.TenBan;
                txtThoiGianDuKien.Text = _selectedItem.ThoiGianDuKien?.ToString() ?? "";
                txtGhiChuBep.Text = _selectedItem.GhiChuBep ?? "";

                // Mở khóa 2 nút chức năng
                btnCapNhat.Enabled = true;
                btnHuyMon.Enabled = true;
            }
        }

        private async void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (_selectedItem == null) return;

            int trangThaiMoi = (int)cbTrangThai.SelectedValue;
            string maDauBep = "";

            // Ràng buộc: Trạng thái = 1 (Đang làm) thì BẮT BUỘC phải chọn Đầu bếp
            if (trangThaiMoi == 1)
            {
                if (cbDauBep.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Đầu bếp phụ trách khi chuyển sang trạng thái Đang làm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Lấy ID Đầu bếp nếu có chọn
            if (cbDauBep.SelectedValue != null)
            {
                maDauBep = cbDauBep.SelectedValue.ToString();
            }

            // Lấy Thời gian dự kiến và kiểm tra kiểu số
            string thoiGianDuKien = "";
            if (!string.IsNullOrWhiteSpace(txtThoiGianDuKien.Text))
            {
                if (!int.TryParse(txtThoiGianDuKien.Text, out _))
                {
                    MessageBox.Show("Thời gian dự kiến phải là số nguyên (phút)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtThoiGianDuKien.Focus();
                    return;
                }
                thoiGianDuKien = txtThoiGianDuKien.Text;
            }

            string ghiChu = txtGhiChuBep.Text.Trim();

            // Lắp ráp chuỗi gửi xuống Server (đúng chuẩn cú pháp ở Bước 2)
            string req = $"UPDATE_KITCHEN_ITEM|{_selectedItem.MaCT}|{trangThaiMoi}|{maDauBep}|{thoiGianDuKien}|{ghiChu}";

            // Tạm khóa nút để chống người dùng bấm đúp 2 lần liên tục
            btnCapNhat.Enabled = false;

            string res = await SocketClient.SendRequestAsync(req);

            btnCapNhat.Enabled = true;

            if (res.Contains("SUCCESS"))
            {
                // Thông báo nhẹ nhàng và xóa form
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearLeftPanel();

                // Ghi chú: Không cần gọi lại hàm LoadKitchenItems() ở đây vì lát nữa 
                // Lệnh Broadcast "RELOAD_KITCHEN_MAP" từ Server gửi về sẽ tự động kích hoạt Load lại!

                await LoadKitchenItems();
            }
            else
            {
                MessageBox.Show(res.Split('|')[1], "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnHuyMon_Click(object sender, EventArgs e)
        {
            if (_selectedItem == null) return;

            string ghiChu = txtGhiChuBep.Text.Trim();

            // Ràng buộc: Hủy thì BẮT BUỘC phải có lý do
            if (string.IsNullOrWhiteSpace(ghiChu))
            {
                MessageBox.Show("Vui lòng nhập lý do hủy vào ô Ghi chú bếp để phục vụ báo lại cho khách!", "Bắt buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhiChuBep.Focus();
                return;
            }

            int trangThaiMoi = 3; // 3 là Đã hủy
            string maDauBep = cbDauBep.SelectedValue?.ToString() ?? "";
            string thoiGianDuKien = ""; // Hủy rồi thì không cần dự kiến nữa

            string req = $"UPDATE_KITCHEN_ITEM|{_selectedItem.MaCT}|{trangThaiMoi}|{maDauBep}|{thoiGianDuKien}|{ghiChu}";
            string res = await SocketClient.SendRequestAsync(req);

            if (res.Contains("SUCCESS"))
            {
                MessageBox.Show("Đã hủy món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearLeftPanel();

                await LoadKitchenItems();
            }
            else
            {
                MessageBox.Show(res.Split('|')[1], "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SocketClient_OnMessageReceived(string message)
        {
            // Chuyển luồng nền về luồng UI (Giao diện) để DataGridView không bị crash Cross-Thread
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SocketClient_OnMessageReceived(message)));
                return;
            }

            // Nếu Phục vụ vừa gửi Order HOẶC Bếp khác vừa cập nhật món xong
            if (message == "RELOAD_TABLE_MAP" || message == "RELOAD_KITCHEN_MAP")
            {
                Console.WriteLine("[REALTIME KITCHEN] Có thay đổi đơn hàng, tải lại lưới...");
                await LoadKitchenItems();
            }
        }
    }
}
