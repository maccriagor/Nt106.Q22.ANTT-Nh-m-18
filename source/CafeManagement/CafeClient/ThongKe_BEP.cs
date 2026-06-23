using CafeCommon;
using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeClient
{
    public partial class ThongKe_BEP : Form
    {
        public ThongKe_BEP()
        {
            InitializeComponent();
            this.Load += async (s, e) =>
            {
                await LoadKitchenStaffComboBox();
            };

        }

        private async Task UpdateBestSellerAsync()
        {
            try
            {
                // 1. Lấy khoảng thời gian từ giao diện lọc ngày
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                // Gửi mã đầu bếp là 0 để lấy toàn bộ dữ liệu ctdonhang của quán trong khoảng thời gian này
                string requestPayload = $"{tuNgay.ToString("yyyy-MM-dd")};{denNgay.ToString("yyyy-MM-dd")};0";

                // 2. Đồng loạt gửi request lên Server để lấy đủ 3 nguồn dữ liệu cần liên kết
                string response = await SocketClient.SendRequestAsync($"GET_KITCHEN_REPORT_DATA|{requestPayload}");
                string menuResponse = await SocketClient.SendRequestAsync("GET_MENU");
                string loaiMonResponse = await SocketClient.SendRequestAsync("GET_LOAI_MON");

                if (response.StartsWith("SUCCESS") && menuResponse.StartsWith("SUCCESS") && loaiMonResponse.StartsWith("SUCCESS"))
                {
                    var jsonReport = response.Split('|')[1];
                    var jsonMenu = menuResponse.Split('|')[1];
                    var jsonLoaiMon = loaiMonResponse.Split('|')[1];

                    // CHÚ Ý SỬA DÒNG NÀY: Thay đổi hoàn toàn từ List<dynamic> sang List<Menu> công khai
                    List<CTDonHang> reportList = JsonConvert.DeserializeObject<List<CTDonHang>>(jsonReport) ?? new List<CTDonHang>();
                    List<CafeCommon.Menu> menuList = JsonConvert.DeserializeObject<List<CafeCommon.Menu>>(jsonMenu) ?? new List<CafeCommon.Menu>();
                    List<CafeCommon.LoaiMon> loaiMonList = JsonConvert.DeserializeObject<List<CafeCommon.LoaiMon>>(jsonLoaiMon) ?? new List<CafeCommon.LoaiMon>();
                    // Làm mới giao diện ListView lvseller
                    lvseller.Items.Clear();

                    if (reportList.Count == 0) return;

                    int tongSoLuongTatCaMon = reportList.Sum(x => x.SoLuong);

                    // Sử dụng LINQ với thực thể Menu chuẩn 100%
                    var bestSellerQuery = reportList
                        .GroupBy(x => x.MaMon)
                        .Select(group =>
                        {
                            int maMon = group.Key;

                            // Lúc này 'menuList' đã là List<Menu> nên biến 'm' sẽ tự động nhận diện được thuộc tính .MaMon và .TenMon không bị lỗi gạch đỏ nữa
                            var itemMenu = menuList.FirstOrDefault(m => m.MaMon == maMon);
                            string tenMon = itemMenu != null ? itemMenu.TenMon : $"Món ăn #{maMon}";

                            string tenLoaiMon = "Chưa phân loại";
                            if (itemMenu != null)
                            {
                                var itemLoai = loaiMonList.FirstOrDefault(l => l.MaLoaiMon == itemMenu.MaLoaiMon);
                                if (itemLoai != null)
                                {
                                    tenLoaiMon = itemLoai.TenLoai;
                                }
                            }

                            int tongSoLuongMon = group.Sum(x => x.SoLuong);
                            int tongSoDonChuaMon = group.Count();
                            double tiLePhanTram = tongSoLuongTatCaMon > 0 ? ((double)tongSoLuongMon / tongSoLuongTatCaMon) * 100 : 0;

                            return new
                            {
                                TenMon = tenMon,
                                LoaiMon = tenLoaiMon,
                                SoLuong = tongSoLuongMon,
                                SoDon = tongSoDonChuaMon,
                                TiLe = tiLePhanTram
                            };
                        })
                        .OrderByDescending(x => x.SoLuong)
                        .ToList();
                    // 5. Duyệt danh sách đã sắp xếp và đổ lên lvseller
                    int stt = 1;
                    foreach (var food in bestSellerQuery)
                    {
                        ListViewItem item = new ListViewItem(stt.ToString());       // Cột STT
                        item.SubItems.Add(food.TenMon);                             // Tên món (tenmon)
                        item.SubItems.Add(food.LoaiMon);                            // Loại món (tenloai)
                        item.SubItems.Add(food.SoLuong.ToString());                 // Số lượng
                        item.SubItems.Add(food.SoDon.ToString());                   // Số đơn
                        item.SubItems.Add($"{food.TiLe:F1}%");                      // Tỉ lệ %

                        lvseller.Items.Add(item);
                        stt++;
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi đồng bộ dữ liệu danh mục món ăn từ Server.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình tính toán Best Seller: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            await UpdateKitchenSummary();
            await UpdateBestSellerAsync();
        }

        private async void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            await UpdateKitchenSummary();
            await UpdateBestSellerAsync();
        }

        private async void cbdaubep_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateKitchenSummary();
        }


        private async Task UpdateKitchenSummary()
        {
            try
            {
                // 1. Kiểm tra và lấy giá trị an toàn từ ComboBox đầu bếp
                int selectedMaDauBep = 0;
                if (cbdaubep.SelectedValue != null)
                {
                    if (cbdaubep.SelectedValue is UserAccount staffObj) selectedMaDauBep = staffObj.MaNguoiDung;
                    else if (cbdaubep.SelectedValue is int idInt) selectedMaDauBep = idInt;
                    else int.TryParse(cbdaubep.SelectedValue.ToString(), out selectedMaDauBep);
                }

                // 2. Gửi request lấy dữ liệu chi tiết đơn hàng
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;
                string requestPayload = $"{tuNgay.ToString("yyyy-MM-dd")};{denNgay.ToString("yyyy-MM-dd")};{selectedMaDauBep}";

                string response = await SocketClient.SendRequestAsync($"GET_KITCHEN_REPORT_DATA|{requestPayload}");
                // Gửi thêm request lấy toàn bộ danh sách bếp để lấy "Họ Tên" hiển thị trên ListView công khai
                string staffResponse = await SocketClient.SendRequestAsync("GET_KITCHEN_STAFF");

                if (response.StartsWith("SUCCESS") && staffResponse.StartsWith("SUCCESS"))
                {
                    var jsonReport = response.Split('|')[1];
                    var jsonStaff = staffResponse.Split('|')[1];

                    List<CTDonHang> reportList = JsonConvert.DeserializeObject<List<CTDonHang>>(jsonReport) ?? new List<CTDonHang>();
                    List<UserAccount> staffList = JsonConvert.DeserializeObject<List<UserAccount>>(jsonStaff) ?? new List<UserAccount>();

                    // --- [PHẦN 1: TÍNH CÁC Ô THÔNG SỐ BÊN TRÁI] ---
                    int tongSoDon = reportList.Count;
                    int tongSoMon = reportList.Sum(x => x.SoLuong);
                    int soDonHoanThanhGlobal = reportList.Count(x => x.TrangThaiItem == 2);

                    tbdon.Text = tongSoDon.ToString();
                    tbmon.Text = tongSoMon.ToString();

                    double tiLeHoanThanhGlobal = tongSoDon > 0 ? ((double)soDonHoanThanhGlobal / tongSoDon) * 100 : 0;
                    tbtile.Text = $"{tiLeHoanThanhGlobal:F1}%";

                    double soNgay = (denNgay - tuNgay).TotalDays + 1;
                    double soDonTrungBinh = tongSoDon / (soNgay <= 0 ? 1 : soNgay);
                    tbtrungbinh.Text = $"{soDonTrungBinh:F1} / ngày";


                    // --- [PHẦN 2: XỬ LÝ DANH SÁCH TOP 3 ĐẦU BẾP (lvdaubep)] ---
                    lvdaubep.Items.Clear(); // Xóa sạch dữ liệu cũ trên giao diện hiển thị

                    // Sử dụng LINQ để gom nhóm dữ liệu theo từng MaNhanVienCheBien
                    var topKitchenQuery = reportList
                        .Where(x => x.MaNhanVienCheBien.HasValue)
                        .GroupBy(x => x.MaNhanVienCheBien.Value)
                        .Select(group =>
                        {
                            int maNhanVien = group.Key;
                            // Tìm họ tên tương ứng từ danh sách nhân viên
                            string tenDauBep = staffList.FirstOrDefault(s => s.MaNguoiDung == maNhanVien)?.HoTen ?? $"Đầu bếp #{maNhanVien}";

                            int tongDonNhanVien = group.Count();
                            int donHoanThanhNhanVien = group.Count(x => x.TrangThaiItem == 2);
                            double tiLeHoanThanhNhanVien = tongDonNhanVien > 0 ? ((double)donHoanThanhNhanVien / tongDonNhanVien) * 100 : 0;

                            int tongMonNhanVien = group.Sum(x => x.SoLuong);
                            // Số món hoàn thành: Tổng SoLuong của các dòng có TrangThaiItem = 2
                            int monHoanThanhNhanVien = group.Where(x => x.TrangThaiItem == 2).Sum(x => x.SoLuong);

                            return new
                            {
                                TenDauBep = tenDauBep,
                                TongSoDon = tongDonNhanVien,
                                DonHoanThanh = donHoanThanhNhanVien,
                                TiLeHoanThanh = tiLeHoanThanhNhanVien,
                                TongSoMon = tongMonNhanVien,
                                MonHoanThanh = monHoanThanhNhanVien
                            };
                        })
                        .OrderByDescending(x => x.TongSoDon) // Sắp xếp giảm dần theo tổng số đơn hàng làm được
                        .Take(3) // Chỉ lấy ra đúng Top 3 người đứng đầu
                        .ToList();

                    // Đổ dữ liệu đã xử lý vào ListView
                    int stt = 1;
                    foreach (var chef in topKitchenQuery)
                    {
                        ListViewItem item = new ListViewItem(stt.ToString()); // Cột Số thứ tự (1-3)
                        item.SubItems.Add(chef.TenDauBep);                     // Tên đầu bếp
                        item.SubItems.Add(chef.TongSoDon.ToString());           // Tổng số đơn
                        item.SubItems.Add(chef.DonHoanThanh.ToString());        // Đơn hoàn thành
                        item.SubItems.Add($"{chef.TiLeHoanThanh:F1}%");          // Tỉ lệ hoàn thành (%)
                        item.SubItems.Add(chef.TongSoMon.ToString());           // Tổng số món
                        item.SubItems.Add(chef.MonHoanThanh.ToString());        // Số món hoàn thành

                        lvdaubep.Items.Add(item);
                        stt++;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lấy dữ liệu thống kê hiệu suất bếp từ Server.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình tính toán thống kê ListView: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadKitchenStaffComboBox()
        {
            try
            {
                // 1. Gửi request lên SocketServer để lấy danh sách nhân viên bếp
                string response = await SocketClient.SendRequestAsync("GET_KITCHEN_STAFF");

                if (response.StartsWith("SUCCESS"))
                {
                    var json = response.Split('|')[1];

                    // 2. Deserialize chuỗi JSON thành danh sách các đối tượng UserAccount
                    var staffList = JsonConvert.DeserializeObject<List<UserAccount>>(json);

                    // 3. Tạo một danh sách mới để chứa cả tùy chọn mặc định "Tất cả đầu bếp"
                    List<UserAccount> displayList = new List<UserAccount>();

                    // Thêm tùy chọn mặc định với MaNguoiDung = 0 (hoặc -1 tùy logic của bạn)
                    displayList.Add(new UserAccount { MaNguoiDung = 0, HoTen = "Tất cả đầu bếp" });

                    // 4. Đổ dữ liệu thật từ database vào danh sách hiển thị
                    if (staffList != null && staffList.Count > 0)
                    {
                        foreach (var staff in staffList)
                        {
                            displayList.Add(staff);
                        }
                    }

                    // 5. Gán DataSource và thiết kế trường hiển thị / giá trị ngầm định
                    cbdaubep.DataSource = displayList;
                    cbdaubep.DisplayMember = "HoTen";       // Hiển thị Họ Tên lên ComboBox
                    cbdaubep.ValueMember = "MaNguoiDung";   // Giá trị thực tế nhận được khi chọn là Mã Người Dùng
                }
                else
                {
                    MessageBox.Show("Không thể lấy danh sách nhân viên bếp từ máy chủ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đầu bếp: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now;

            // Chọn lại vị trí đầu tiên của combobox ("Tất cả đầu bếp")
            if (cbdaubep.Items.Count > 0)
            {
                cbdaubep.SelectedIndex = 0;
            }

            // Gọi nạp lại dữ liệu cho toàn bộ các bảng
            await UpdateKitchenSummary();
            await UpdateBestSellerAsync();

            MessageBox.Show("Dữ liệu báo cáo đã được cập nhật mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Thu thập dữ liệu khoảng thời gian hiện tại từ giao diện lọc
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                // Gửi mã 0 để luôn lấy TRỌN VẸN toàn bộ chi tiết đơn hàng của quán phục vụ việc làm báo cáo tổng quan
                string requestPayload = $"{tuNgay.ToString("yyyy-MM-dd")};{denNgay.ToString("yyyy-MM-dd")};0";

                // Gửi đồng thời các request lên Server để lấy dữ liệu thô phục vụ tính toán
                string response = await SocketClient.SendRequestAsync($"GET_KITCHEN_REPORT_DATA|{requestPayload}");
                string staffResponse = await SocketClient.SendRequestAsync("GET_KITCHEN_STAFF");
                string menuResponse = await SocketClient.SendRequestAsync("GET_MENU");
                string loaiMonResponse = await SocketClient.SendRequestAsync("GET_LOAI_MON");

                if (!response.StartsWith("SUCCESS") || !staffResponse.StartsWith("SUCCESS") ||
                    !menuResponse.StartsWith("SUCCESS") || !loaiMonResponse.StartsWith("SUCCESS"))
                {
                    MessageBox.Show("Không thể tải đầy đủ dữ liệu từ máy chủ để lập báo cáo Excel.", "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Giải mã JSON thành các danh sách Object thực thể dữ liệu tĩnh
                var reportList = JsonConvert.DeserializeObject<List<CTDonHang>>(response.Split('|')[1]) ?? new List<CTDonHang>();
                var staffList = JsonConvert.DeserializeObject<List<UserAccount>>(staffResponse.Split('|')[1]) ?? new List<UserAccount>();
                var menuList = JsonConvert.DeserializeObject<List<CafeCommon.Menu>>(menuResponse.Split('|')[1]) ?? new List<CafeCommon.Menu>();
                var loaiMonList = JsonConvert.DeserializeObject<List<CafeCommon.LoaiMon>>(loaiMonResponse.Split('|')[1]) ?? new List<CafeCommon.LoaiMon>();

                // 2. Khởi tạo đối tượng XLWorkbook của ClosedXML
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    // ==========================================
                    // SHEET 1: BÁO CÁO HIỆU SUẤT NHÂN VIÊN
                    // ==========================================
                    var worksheet1 = workbook.Worksheets.Add("Báo cáo hiệu suất nhân viên");

                    // Tạo tiêu đề Header cho các cột dữ liệu sheet 1
                    string[] headers1 = { "STT", "Tên đầu bếp", "Tổng số đơn", "Đơn hoàn thành", "Tỉ lệ hoàn thành", "Tổng số món", "Số món hoàn thành" };
                    for (int i = 0; i < headers1.Length; i++)
                    {
                        var cell = worksheet1.Cell(1, i + 1);
                        cell.Value = headers1[i];
                        cell.Style.Font.Bold = true; // Định dạng Header bôi đậm chữ
                    }

                    // Tính toán hiệu suất cho TOÀN BỘ đầu bếp trong danh sách hệ thống
                    int sttChef = 1;
                    int rowChef = 2;
                    foreach (var staff in staffList)
                    {
                        // Lấy tất cả các dòng đơn hàng mà đầu bếp này đảm nhận chế biến
                        var chefOrders = reportList.Where(x => x.MaNhanVienCheBien == staff.MaNguoiDung).ToList();

                        int tongSoDon = chefOrders.Count;
                        int donHoanThanh = chefOrders.Count(x => x.TrangThaiItem == 2);
                        double tiLeHoanThanh = tongSoDon > 0 ? ((double)donHoanThanh / tongSoDon) * 100 : 0;
                        int tongSoMon = chefOrders.Sum(x => x.SoLuong);
                        int monHoanThanh = chefOrders.Where(x => x.TrangThaiItem == 2).Sum(x => x.SoLuong);

                        // Đổ dữ liệu tính được vào từng dòng cột tương ứng
                        worksheet1.Cell(rowChef, 1).Value = sttChef;
                        worksheet1.Cell(rowChef, 2).Value = staff.HoTen;
                        worksheet1.Cell(rowChef, 3).Value = tongSoDon;
                        worksheet1.Cell(rowChef, 4).Value = donHoanThanh;
                        worksheet1.Cell(rowChef, 5).Value = $"{tiLeHoanThanh:F1}%";
                        worksheet1.Cell(rowChef, 6).Value = tongSoMon;
                        worksheet1.Cell(rowChef, 7).Value = monHoanThanh;

                        sttChef++;
                        rowChef++;
                    }
                    worksheet1.Columns().AdjustToContents(); // Thiết lập AutoFit căn chỉnh độ rộng cột tự động

                    // ==========================================
                    // SHEET 2: THỐNG KÊ MÓN ĂN
                    // ==========================================
                    var worksheet2 = workbook.Worksheets.Add("Thống kê món ăn");

                    // Tạo tiêu đề Header cho các cột dữ liệu sheet 2
                    string[] headers2 = { "STT", "Tên món", "Loại món", "Số lượng", "Số đơn", "Tỉ lệ sản lượng" };
                    for (int i = 0; i < headers2.Length; i++)
                    {
                        var cell = worksheet2.Cell(1, i + 1);
                        cell.Value = headers2[i];
                        cell.Style.Font.Bold = true; // Định dạng Header bôi đậm chữ
                    }

                    // Tính toán tổng số lượng của TẤT CẢ các món làm mẫu số tính tỷ lệ đóng góp sản lượng toàn cửa hàng
                    int tongSoLuongTatCaMon = reportList.Sum(x => x.SoLuong);

                    int sttFood = 1;
                    int rowFood = 2;
                    foreach (var menu in menuList)
                    {
                        // Lấy tất cả các dòng chi tiết đơn hàng tương ứng với mã món ăn hiện tại
                        var foodOrders = reportList.Where(x => x.MaMon == menu.MaMon).ToList();

                        // Truy xuất tên loại món dựa trên MaLoaiMon bắc cầu sang bảng loaimon
                        var itemLoai = loaiMonList.FirstOrDefault(l => l.MaLoaiMon == menu.MaLoaiMon);
                        string tenLoaiMon = itemLoai != null ? itemLoai.TenLoai : "Chưa phân loại";

                        int soLuongBaoCao = foodOrders.Sum(x => x.SoLuong);
                        int soDonBaoCao = foodOrders.Count; // Số đơn tương ứng với số hàng xuất hiện mã món
                        double tiLeBaoCao = tongSoLuongTatCaMon > 0 ? ((double)soLuongBaoCao / tongSoLuongTatCaMon) * 100 : 0;

                        // Ghi dữ liệu vào các ô trang tính excel
                        worksheet2.Cell(rowFood, 1).Value = sttFood;
                        worksheet2.Cell(rowFood, 2).Value = menu.TenMon;
                        worksheet2.Cell(rowFood, 3).Value = tenLoaiMon;
                        worksheet2.Cell(rowFood, 4).Value = soLuongBaoCao;
                        worksheet2.Cell(rowFood, 5).Value = soDonBaoCao;
                        worksheet2.Cell(rowFood, 6).Value = $"{tiLeBaoCao:F1}%";

                        sttFood++;
                        rowFood++;
                    }
                    worksheet2.Columns().AdjustToContents(); // Thiết lập AutoFit căn chỉnh độ rộng cột tự động

                    // 3. Thực hiện lưu tệp tin Excel vào thư mục tạm thời của hệ thống
                    string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath); // Tạo thư mục nếu chưa tồn tại
                    }

                    string fileName = $"BaoCao_NhaBep_{tuNgay:yyyyMMdd}_To_{denNgay:yyyyMMdd}.xlsx";
                    string filePath = Path.Combine(folderPath, fileName);

                    workbook.SaveAs(filePath); // Lưu file dữ liệu

                    // 4. Mở luôn tệp tin đó lên cho người dùng xem bằng Process.Start
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true // Cần thiết lập True để chạy ứng dụng mặc định xử lý file hệ thống (.xlsx)
                    };
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tạo hoặc mở báo cáo Excel: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
