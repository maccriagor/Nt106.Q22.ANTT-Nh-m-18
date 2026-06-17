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
    public partial class Order_Ban : Form
    {
        private List<BanAn> _allTables = new List<BanAn>();
        private List<CafeCommon.Menu> _currentMenu = new List<CafeCommon.Menu>();
        private BindingList<CTDonHang> _cart = new BindingList<CTDonHang>();
        public Order_Ban()
        {
            InitializeComponent();

            // Kiểm tra quyền truy cập - Kitchen không được phép mở form này
            if (UserSession.VaiTro == "Kitchen")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này! Chỉ Waiter (nhân viên phục vụ) mới có thể quản lý order.", "Lỗi quyền hạn", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }

            // ĐĂNG KÝ Khi Socket nhận tin, hãy gọi hàm xử lý của tôi
            SocketClient.OnMessageReceived += SocketClient_OnMessageReceived;

            // đăng ký handler đúng kiểu delegate (dùng nullable-aware signatures below)
            dgvGioHang.CellFormatting += dgvGioHang_CellFormatting;
            dgvMenu.CellFormatting += DgvMenu_CellFormatting;

            // ensure separate BindingContext so comboboxes don't share currency manager
            cbBanMuonChuyenDen.BindingContext = new BindingContext();
            cbSoBan.BindingContext = new BindingContext();
            cbBanMuonChuyenDen.SelectedIndexChanged += cbBanMuonChuyenDen_SelectedIndexChanged;
        }

        // Hàm xử lý tin nhắn Real-time
        private async void SocketClient_OnMessageReceived(string message)
        {
            // Đảm bảo đưa tác vụ về lại đúng luồng UI chính
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SocketClient_OnMessageReceived(message)));
                return;
            }

            if (message == "RELOAD_TABLE_MAP")
            {
                Console.WriteLine("[REALTIME] Đã nhận lệnh làm mới sơ đồ bàn từ Server!");

                // Gọi thẳng hàm ở đây, nó sẽ chạy an toàn trên luồng UI
                await LoadTablesFromServer();
            }
        }

        // Hàm tải dữ liệu (Viết riêng ra để dùng chung)
        private async Task LoadTablesFromServer()
        {
            string response = await SocketClient.SendRequestAsync("GET_TABLES");
            if (response.Contains("SUCCESS"))
            {
                string json = response.Split('|')[1];

                // THÊM CẤU HÌNH NÀY: Hướng dẫn Client cách đọc chuỗi ngày tháng của Việt Nam (dd/MM/yyyy)
                var settings = new JsonSerializerSettings
                {
                    Culture = new System.Globalization.CultureInfo("vi-VN"),
                    // Tùy chọn nâng cao: Bỏ qua các lỗi Parse ngày tháng nếu DB gửi giá trị rác
                    Error = (sender, args) =>
                    {
                        if (args.ErrorContext.Member.ToString() == "NgayTao")
                            args.ErrorContext.Handled = true;
                    }
                };

                // Gắn settings vào hàm dịch JSON
                _allTables = JsonConvert.DeserializeObject<List<BanAn>>(json, settings) ?? new List<BanAn>();

                DrawTableMap(_allTables);

                // use separate BindingSource instances (prevents selection sync)
                var bs1 = new BindingSource { DataSource = _allTables };
                cbSoBan.DataSource = bs1;
                cbSoBan.DisplayMember = "TenBan";

                var bs2 = new BindingSource { DataSource = _allTables };
                cbBanMuonChuyenDen.DataSource = bs2;
                cbBanMuonChuyenDen.DisplayMember = "TenBan";
                cbBanMuonChuyenDen.ValueMember = "MaBanAn";

                if (_allTables.Count > 0) cbSoBan.SelectedIndex = 0;
            }
            else
            {
                _allTables = new List<BanAn>();
                cbSoBan.DataSource = null;
                cbBanMuonChuyenDen.DataSource = null;
                DrawTableMap(_allTables);
            }
        }


        private async void Order_Ban_Load(object sender, EventArgs e)
        {
            await LoadTablesFromServer();
            await LoadCategories();

            // Thiết lập DataGridView cho giỏ hàng: chỉ hiển thị cột cần thiết
            ConfigureGioHangGrid();

            // Thiết lập DataGridView cho Menu (cột cố định)
            ConfigureMenuGrid();

            dgvGioHang.DataSource = _cart; // Gán nguồn cho DataGridView Giỏ hàng

            // Load menu mặc định: "Tất cả"
            await LoadMenuByCategory(0);
        }

        private async Task LoadCategories()
        {
            string res = await SocketClient.SendRequestAsync("GET_CATEGORIES");
            if (res.Contains("SUCCESS"))
            {
                var categories = JsonConvert.DeserializeObject<List<LoaiMon>>(res.Split('|')[1]) ?? new List<LoaiMon>();

                // Thêm lựa chọn "Tất cả" ở đầu danh sách với MaLoaiMon = 0
                var allItem = new LoaiMon { MaLoaiMon = 0, TenLoai = "Tất cả" };
                categories.Insert(0, allItem);

                cbLoaiMonAn.DataSource = categories;
                cbLoaiMonAn.DisplayMember = "TenLoai";
                cbLoaiMonAn.ValueMember = "MaLoaiMon";
                cbLoaiMonAn.SelectedIndex = 0; // mặc định "Tất cả"
            }
            else
            {
                cbLoaiMonAn.DataSource = new List<LoaiMon> { new LoaiMon { MaLoaiMon = 0, TenLoai = "Tất cả" } };
            }
        }

        // Load menu theo category (0 => all)
        private async Task LoadMenuByCategory(int cateId)
        {
            string cmd = cateId == 0 ? "GET_ALL_MENU" : $"GET_MENU_BY_CATEGORY|{cateId}";
            string res = await SocketClient.SendRequestAsync(cmd);
            if (res.Contains("SUCCESS") || !res.StartsWith("ERROR"))
            {
                // Server returns just JSON for some requests; handle both forms
                string json = res.Contains("|") ? res.Split('|')[1] : res;
                _currentMenu = JsonConvert.DeserializeObject<List<CafeCommon.Menu>>(json) ?? new List<CafeCommon.Menu>();

                // Gán và hiển thị theo cột đã cấu hình
                dgvMenu.DataSource = null;
                dgvMenu.DataSource = _currentMenu;
            }
            else
            {
                _currentMenu = new List<CafeCommon.Menu>();
                dgvMenu.DataSource = null;
            }
        }

        private void ConfigureMenuGrid()
        {
            // Cấu hình hiển thị cột cho dgvMenu: Mã món, Tên món, Giá, Trạng thái, Mã loại món
            dgvMenu.AutoGenerateColumns = false;
            dgvMenu.Columns.Clear();

            var cMa = new DataGridViewTextBoxColumn { Name = "MaMon", HeaderText = "Mã món", DataPropertyName = "MaMon", ReadOnly = true };
            var cTen = new DataGridViewTextBoxColumn { Name = "TenMon", HeaderText = "Tên món", DataPropertyName = "TenMon", ReadOnly = true };
            var cGia = new DataGridViewTextBoxColumn { Name = "Gia", HeaderText = "Giá", DataPropertyName = "Gia", ReadOnly = true };
            var cTrangThai = new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", ReadOnly = true };
            var cMaLoai = new DataGridViewTextBoxColumn { Name = "MaLoaiMon", HeaderText = "Mã loại", DataPropertyName = "MaLoaiMon", ReadOnly = true };

            dgvMenu.Columns.AddRange(new DataGridViewColumn[] { cMa, cTen, cGia, cTrangThai, cMaLoai });

            // Optionally format Gia as currency
            dgvMenu.CellFormatting -= DgvMenu_CellFormatting;
            dgvMenu.CellFormatting += DgvMenu_CellFormatting;
        }

        private void DgvMenu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMenu.Columns[e.ColumnIndex].Name == "Gia" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal v))
                {
                    e.Value = v.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void ConfigureGioHangGrid()
        {
            dgvGioHang.AutoGenerateColumns = false;
            dgvGioHang.Columns.Clear();

            var cMaMon = new DataGridViewTextBoxColumn { Name = "MaMon", HeaderText = "Mã món", DataPropertyName = "MaMon", ReadOnly = true };
            var cTenMon = new DataGridViewTextBoxColumn { Name = "TenMon", HeaderText = "Tên món", DataPropertyName = "TenMon", ReadOnly = true };
            var cDonGia = new DataGridViewTextBoxColumn { Name = "DonGia", HeaderText = "Đơn giá", DataPropertyName = "DonGia", ReadOnly = true };
            var cSoLuong = new DataGridViewTextBoxColumn { Name = "SoLuong", HeaderText = "Số lượng", DataPropertyName = "SoLuong", ReadOnly = false };
            // mới: cột Ghi chú khách
            var cGhiChu = new DataGridViewTextBoxColumn { Name = "GhiChuKhach", HeaderText = "Ghi chú khách", DataPropertyName = "GhiChuKhach", ReadOnly = true };

            dgvGioHang.Columns.AddRange(new DataGridViewColumn[] { cMaMon, cTenMon, cDonGia, cSoLuong, cGhiChu });
        }

        // Format cell giỏ hàng để hiện tên món từ _currentMenu
        private void dgvGioHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var colName = dgvGioHang.Columns[e.ColumnIndex].Name;
                if (colName == "TenMon")
                {
                    var row = dgvGioHang.Rows[e.RowIndex];
                    var item = row.DataBoundItem as CTDonHang;
                    if (item != null)
                    {
                        var menu = _currentMenu.FirstOrDefault(m => m.MaMon == item.MaMon);
                        e.Value = menu?.TenMon ?? string.Empty;
                        e.FormattingApplied = true;
                    }
                }
                else if (colName == "DonGia" && e.Value != null)
                {
                    if (decimal.TryParse(e.Value.ToString(), out decimal v))
                    {
                        e.Value = v.ToString("N0");
                        e.FormattingApplied = true;
                    }
                }
                else if (colName == "GhiChuKhach")
                {
                    var row = dgvGioHang.Rows[e.RowIndex];
                    var item = row.DataBoundItem as CTDonHang;
                    e.Value = item?.GhiChuKhach ?? string.Empty;
                    e.FormattingApplied = true;
                }
            }
            catch { }
        }

        private void DrawTableMap(List<BanAn> tables)
        {
            flpTables.Controls.Clear(); // Xóa sạch các bàn cũ trước khi vẽ lại

            foreach (var item in tables)
            {
                // 1. Tạo một Button cho mỗi bàn
                Button btn = new Button();
                btn.Width = 110; // Độ rộng ô vuông
                btn.Height = 110; // Độ cao ô vuông
                btn.Text = $"{item.TenBan}{Environment.NewLine}({item.SoChoNgoi} chỗ)";
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Margin = new Padding(10);
                btn.Cursor = Cursors.Hand;

                // 2. Lưu toàn bộ đối tượng bàn vào Tag để khi click lấy ra dùng
                btn.Tag = item;

                // 3. Đổi màu theo trạng thái
                switch (item.TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.Green; // Màu xanh
                        break;
                    case "Có khách":
                        btn.BackColor = Color.MistyRose; // Màu đỏ nhạt
                        btn.ForeColor = Color.Red;
                        break;
                    case "Đã đặt":
                        btn.BackColor = Color.LightGray; // Màu xám
                        break;
                }

                // 4. Gán sự kiện Click cho nút bàn
                btn.Click += BtnTable_Click;

                // 5. Thêm nút vào FlowLayoutPanel
                flpTables.Controls.Add(btn);
            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;                // bảo vệ nếu sender không phải Button

            var table = btn.Tag as BanAn;
            if (table == null) return;              // bảo vệ nếu Tag null hoặc không phải BanAn

            // tiếp tục xử lý an toàn
            cbSoBan.SelectedItem = table;
            UpdateSelectedTableUI(table);
        }

        // Xử lý khi người dùng chọn bàn trong combobox
        private void CbSoBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Hàm tái sử dụng để cập nhật UI dựa trên một đối tượng BanAn
        private void UpdateSelectedTableUI(BanAn table)
        {
            cbSoBan.Text = table.TenBan;

            bool isEmpty = string.Equals(table.TrangThai, "Trống", StringComparison.OrdinalIgnoreCase);
            lbTrangThaiBan.Text = isEmpty ? $"Trống ({table.SoChoNgoi} chỗ)" : table.TrangThai;
            lbTrangThaiBan.ForeColor = isEmpty ? Color.Green : Color.Red;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Nút ĐẶT BÀN
        private async void btnDatBan_Click(object sender, EventArgs e)
        {
            var table = cbSoBan.SelectedItem as BanAn;

            // Ràng buộc 1: Chưa chọn bàn
            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn ăn từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ràng buộc 2: Bàn không trống
            if (table.TrangThai == "Có khách")
            {
                MessageBox.Show("Bàn này đang có khách ngồi ăn, không thể đặt trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (table.TrangThai == "Đã đặt")
            {
                MessageBox.Show("Bàn này đã được người khác đặt trước đó rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn đặt giữ bàn '{table.TenBan}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                // Khóa nút để tránh nhân viên click liên tục khi mạng chậm
                btnDatBan.Enabled = false;

                string res = await SocketClient.SendRequestAsync($"UPDATE_TABLE_STATUS|{table.MaBanAn}|Đã đặt");

                if (res.Contains("SUCCESS"))
                {
                    MessageBox.Show("Đã đặt giữ bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTablesFromServer();
                }
                else
                {
                    // Tách chuỗi để lấy câu thông báo lỗi sạch từ Server (bỏ chữ FAIL|)
                    string errorMsg = res.Contains("|") ? res.Split('|')[1] : res;
                    MessageBox.Show("Đặt bàn thất bại: " + errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mất kết nối tới Server: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDatBan.Enabled = true; // Mở khóa nút khi đã xử lý xong
            }
        }
        
        private async void btnHuyBan_Click(object sender, EventArgs e)
        {
            var table = cbSoBan.SelectedItem as BanAn;

            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thực hiện thao tác hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (table.TrangThai == "Trống")
            {
                MessageBox.Show("Bàn này đang trống sẵn rồi, không có gì để hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nghiệp vụ phân tách lời nhắc dựa theo độ nghiêm trọng của trạng thái
            string confirmMsg = $"Bạn có chắc muốn hủy trạng thái đặt của bàn '{table.TenBan}' không?";
            if (table.TrangThai == "Có khách")
            {
                confirmMsg = $"CẢNH BÁO NGUY HIỂM: Bàn '{table.TenBan}' đang có khách! \nHành động này sẽ HỦY TOÀN BỘ MÓN ĂN đã gọi và HỦY HÓA ĐƠN của bàn này.\nBạn có chắc chắn muốn tiếp tục?";
            }

            var confirm = MessageBox.Show(confirmMsg, "Xác nhận hủy trạng thái", MessageBoxButtons.YesNo,
                                            table.TrangThai == "Có khách" ? MessageBoxIcon.Warning : MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                btnHuyBan.Enabled = false;

                string res = await SocketClient.SendRequestAsync($"UPDATE_TABLE_STATUS|{table.MaBanAn}|Trống");

                if (res.Contains("SUCCESS"))
                {
                    MessageBox.Show("Đã hủy trạng thái bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTablesFromServer();
                }
                else
                {
                    string errorMsg = res.Contains("|") ? res.Split('|')[1] : res;
                    MessageBox.Show("Hủy trạng thái thất bại: " + errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Socket: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnHuyBan.Enabled = true;
            }
        }

        private void cbSoBan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var table = cbSoBan.SelectedItem as BanAn;
            if (table != null)
            {
                UpdateSelectedTableUI(table);
            }
        }

        // Khi chọn loại món -> Load món tương ứng
        private async void cbLoaiMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiMonAn.SelectedValue is int cateId)
            {
                await LoadMenuByCategory(cateId);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Ràng buộc 1: Kiểm tra xem nhân viên đã chọn món từ thực đơn chưa
            if (dgvMenu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một món ăn từ danh sách Thực đơn bên trên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMenu = dgvMenu.CurrentRow.DataBoundItem as CafeCommon.Menu;
            if (selectedMenu == null) return;

            int qty = (int)nmSoLuong.Value;

            // Ràng buộc 2: Chặn việc thêm số lượng bằng 0
            if (qty == 0)
            {
                MessageBox.Show("Số lượng thêm hoặc bớt món ăn phải khác 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm xem món ăn này đã xuất hiện trong Giỏ hàng cục bộ chưa
            var existingItem = _cart.FirstOrDefault(x => x.MaMon == selectedMenu.MaMon);

            if (existingItem != null)
            {
                // TRƯỜNG HỢP 1: Món đã tồn tại -> Tiến hành cộng dồn số lượng
                int finalQty = existingItem.SoLuong + qty;

                if (finalQty <= 0)
                {
                    // Nếu tổng số lượng sau khi giảm về bằng 0 hoặc âm -> Xóa hẳn khỏi giỏ
                    _cart.Remove(existingItem);
                }
                else
                {
                    // Nếu số lượng hợp lệ -> Cập nhật số lượng mới
                    existingItem.SoLuong = finalQty;
                    _cart.ResetBindings(); // Đẩy dữ liệu cập nhật trực tiếp lên DataGridView
                }
            }
            else
            {
                // TRƯỜNG HỢP 2: Món mới hoàn toàn
                // Ràng buộc 3: Món mới thêm vào giỏ không được phép có số lượng âm
                if (qty <= 0)
                {
                    MessageBox.Show("Món ăn mới thêm vào Giỏ hàng phải có số lượng lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo cấu trúc chi tiết món ăn mới để đưa vào giỏ
                var newCartItem = new CTDonHang
                {
                    MaMon = selectedMenu.MaMon,
                    SoLuong = qty,
                    DonGia = selectedMenu.Gia,
                    GhiChuKhach = txtGhiChu.Text.Trim(),
                    MaNhanVienCheBien = UserSession.MaNguoiDung // Gán ID người dùng tiếp nhận order
                };

                _cart.Add(newCartItem);
            }

            // Reset lại trạng thái các Control nhập liệu để nhân viên chọn món tiếp theo nhanh hơn
            txtGhiChu.Clear();
            nmSoLuong.Value = 1; // Mặc định trả về số lượng là 1
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Ràng buộc: Phải chọn dòng trong giỏ hàng mới cho phép xóa
            if (dgvGioHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng món ăn trong Giỏ hàng cần xóa bỏ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = dgvGioHang.CurrentRow.DataBoundItem as CTDonHang;
            if (item == null) return;

            // Tìm tên món ăn phục vụ cho thông báo dựa trên _currentMenu
            var menuInfo = _currentMenu.FirstOrDefault(m => m.MaMon == item.MaMon);
            string displayMonName = menuInfo != null ? menuInfo.TenMon : $"Món ăn mã #{item.MaMon}";

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa hoàn toàn món '{displayMonName}' ra khỏi giỏ hàng không?",
                                            "Xác nhận xóa món", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _cart.Remove(item);
            }
        }

        private async void btnGuiOrder_Click(object sender, EventArgs e)
        {
            // Ràng buộc 0: Kiểm tra quyền - Kitchen không được phép gửi order
            if (UserSession.VaiTro == "Kitchen")
            {
                MessageBox.Show("Bạn không có quyền gửi đơn hàng! Chỉ nhân viên phục vụ (Waiter) mới được phép gửi order.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var table = cbSoBan.SelectedItem as BanAn;

            // Ràng buộc 1: Chưa xác định số bàn
            if (table == null)
            {
                MessageBox.Show("Vui lòng xác định số bàn ăn trước khi thực hiện gửi Order!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ràng buộc 2: Giỏ hàng trống
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng hiện tại đang trống! Vui lòng chọn món ăn trước khi gửi đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xây dựng chuỗi tóm tắt đơn hàng chuyên nghiệp cho nhân viên đối chiếu với khách
            string orderSummary = $"XÁC NHẬN CHỐT ĐƠN - {table.TenBan.ToUpper()}\n\n";
            foreach (var item in _cart)
            {
                var menuInfo = _currentMenu.FirstOrDefault(m => m.MaMon == item.MaMon);
                string name = menuInfo != null ? menuInfo.TenMon : $"Mã món {item.MaMon}";
                orderSummary += $"• {name} [SL: {item.SoLuong}]\n";
            }
            orderSummary += "\nGửi thông tin đơn hàng này xuống bộ phận nhà bếp?";

            var confirm = MessageBox.Show(orderSummary, "Xác nhận gửi đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                // Khóa nút tương tác để ngăn chặn nhân viên bấm liên tục khi mạng trễ
                btnGuiOrder.Enabled = false;

                // 1. Chuyển giỏ hàng sang chuỗi JSON
                string jsonCart = JsonConvert.SerializeObject(_cart.ToList());

                // 2. Đóng gói chuẩn 4 phần theo đúng định dạng Server chờ: SUBMIT_ORDER|MaBan|MaNV|JSON_GioHang
                string request = $"SUBMIT_ORDER|{table.MaBanAn}|{UserSession.MaNguoiDung}|{JsonConvert.SerializeObject(_cart.ToList())}";

                string res = await SocketClient.SendRequestAsync(request);

                if (res.Contains("SUCCESS"))
                {
                    MessageBox.Show("Hệ thống đã gửi đơn hàng thành công xuống nhà bếp và khởi tạo hóa đơn treo!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa sạch giỏ hàng cục bộ để chuẩn bị phục vụ phiên gọi món tiếp theo
                    _cart.Clear();
                    txtGhiChu.Clear();

                    // Tải lại sơ đồ bàn ngay lập tức để cập nhật trạng thái màu sắc mới nhất
                    await LoadTablesFromServer();
                }
                else
                {
                    string errorMsg = res.Contains("|") ? res.Split('|')[1] : res;
                    MessageBox.Show("Gửi Order thất bại: " + errorMsg, "Lỗi xử lý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đường truyền thiết bị hoặc mất kết nối Server: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Mở khóa nút tương tác khi luồng xử lý Socket hoàn thành ổn định
                btnGuiOrder.Enabled = true;
            }
        }

        private async void btnChuyenBan_Click(object sender, EventArgs e)
        {
            var fromTable = cbSoBan.SelectedItem as BanAn;
            var toTable = cbBanMuonChuyenDen.SelectedItem as BanAn;

            // Ràng buộc 1: Chưa chọn đủ bàn
            if (fromTable == null || toTable == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ cả Bàn hiện tại và Bàn muốn chuyển đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ràng buộc 2: Chuyển trùng bàn
            if (fromTable.MaBanAn == toTable.MaBanAn)
            {
                MessageBox.Show("Bàn muốn chuyển đến không được trùng với bàn hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ràng buộc 3: Bàn đi không có khách
            if (fromTable.TrangThai != "Có khách")
            {
                MessageBox.Show($"Bàn '{fromTable.TenBan}' hiện đang không có khách ngồi, không có hóa đơn nào để chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ràng buộc 4: Bàn đến không trống (đang có khách hoặc đã bị đặt trước)
            if (toTable.TrangThai != "Trống")
            {
                MessageBox.Show($"Bàn đích '{toTable.TenBan}' hiện đang [{toTable.TrangThai}]. Bạn chỉ được chuyển khách vào bàn đang TRỐNG!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có muốn chuyển toàn bộ hóa đơn từ '{fromTable.TenBan}' sang '{toTable.TenBan}' không?", "Xác nhận chuyển bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                btnChuyenBan.Enabled = false;

                string res = await SocketClient.SendRequestAsync($"TRANSFER_TABLE|{fromTable.MaBanAn}|{toTable.MaBanAn}");

                if (res.Contains("SUCCESS"))
                {
                    MessageBox.Show("Đã chuyển bàn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTablesFromServer();
                }
                else
                {
                    string errorMsg = res.Contains("|") ? res.Split('|')[1] : res;
                    MessageBox.Show("Chuyển bàn thất bại: " + errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đường truyền mạng: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnChuyenBan.Enabled = true;
            }
        }


        private void cbBanMuonChuyenDen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
