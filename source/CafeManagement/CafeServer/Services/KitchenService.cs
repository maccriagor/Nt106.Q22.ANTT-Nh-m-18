using CafeCommon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CafeServer.Services
{
    public class KitchenService
    {
        // Lấy danh sách tài khoản của bộ phận Bếp
        public async Task<List<UserAccount>> GetKitchenStaffAsync()
        {
            try
            {
                var res = await DatabaseService.Client.From<UserAccount>()
                    .Where(x => x.VaiTro == "Kitchen")
                    .Order(x => x.HoTen, Ordering.Ascending) // Sắp xếp theo tên từ A-Z cho dễ nhìn
                    .Get();
                return res.Models ?? new List<UserAccount>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KitchenService] Error in GetKitchenStaffAsync: {ex.Message}");
                return new List<UserAccount>();
            }
        }

        // Kéo danh sách món ăn đang Chờ (0) hoặc Đang làm (1)
        public async Task<List<ChiTietOrderDTO>> GetPendingKitchenItemsAsync()
        {
            try
            {
                // 1. Lấy tất cả chi tiết đơn hàng đang ở trạng thái 0 và 1
                var ctRes = await DatabaseService.Client.From<CTDonHang>().Get();
                var activeItems = ctRes.Models.Where(x => x.TrangThaiItem == 0 || x.TrangThaiItem == 1).ToList();

                if (!activeItems.Any()) return new List<ChiTietOrderDTO>();

                // 2. Kéo các bảng liên quan về để dịch ID sang Tên (Chỉ kéo Data cần thiết)
                var donHangRes = await DatabaseService.Client.From<DonHang>().Get();
                var menuRes = await DatabaseService.Client.From<Menu>().Get();
                var banAnRes = await DatabaseService.Client.From<BanAn>().Get();
                var userRes = await DatabaseService.Client.From<UserAccount>().Get();

                // 3. Tiến hành ghép nối (JOIN) tạo thành danh sách DTO
                var dtoList = new List<ChiTietOrderDTO>();

                foreach (var item in activeItems)
                {
                    var dh = donHangRes.Models.FirstOrDefault(x => x.MaDonHang == item.MaDonHang);
                    var mon = menuRes.Models.FirstOrDefault(x => x.MaMon == item.MaMon);
                    var ban = dh != null ? banAnRes.Models.FirstOrDefault(x => x.MaBanAn == dh.MaBanAn) : null;
                    var nvOrder = dh != null ? userRes.Models.FirstOrDefault(x => x.MaNguoiDung == dh.MaNVOrder) : null;

                    var dto = new ChiTietOrderDTO
                    {
                        MaCT = item.MaCT,
                        MaDonHang = item.MaDonHang ?? 0,
                        TenMon = mon != null ? mon.TenMon : "Món không xác định",
                        TenBan = ban != null ? ban.TenBan : "Bàn không xác định",
                        TenNVOrder = nvOrder != null ? nvOrder.HoTen : "Không rõ NV",
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia,
                        UuTien = item.UuTien,
                        GhiChuKhach = item.GhiChuKhach,
                        GhiChuBep = item.GhiChuBep,
                        TrangThaiItem = item.TrangThaiItem,
                        MaNhanVienCheBien = item.MaNhanVienCheBien,
                        NgayOrder = dh?.NgayOrder,
                        ThoiGianBatDau = item.ThoiGianBatDau,
                        ThoiGianHoanThanh = item.ThoiGianHoanThanh,
                        ThoiGianDuKien = item.ThoiGianDuKien
                    };

                    dtoList.Add(dto);
                }

                // Ưu tiên hiển thị: Món nào gọi trước (NgayOrder cũ nhất) lên trên cùng
                return dtoList.OrderBy(x => x.NgayOrder).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KitchenService] GetPendingItems Error: {ex.Message}");
                return new List<ChiTietOrderDTO>();
            }
        }

        // "Bộ não" xử lý nghiệp vụ bếp (Cập nhật trạng thái và tự động tính toán thời gian)
        public async Task<string> UpdateKitchenItemAsync(int maCT, int trangThaiMoi, int? maDauBep, int? thoiGianDuKien, string ghiChu)
        {
            try
            {
                // 1. Lấy dữ liệu hiện tại của món ăn ra để kiểm tra mốc thời gian cũ
                var res = await DatabaseService.Client.From<CTDonHang>()
                    .Where(x => x.MaCT == maCT)
                    .Get();

                var currentItem = res.Models.FirstOrDefault();

                if (currentItem == null)
                    return "FAIL|Món ăn này không tồn tại hoặc đã bị xóa khỏi hệ thống!";

                // 2. Khởi tạo đối tượng chuẩn bị Update
                var updateQuery = DatabaseService.Client.From<CTDonHang>()
                    .Where(x => x.MaCT == maCT)
                    .Set(x => x.TrangThaiItem, trangThaiMoi); // Luôn luôn cập nhật trạng thái mới

                DateTime now = DateTime.Now;

                // 3. Phân luồng xử lý theo Trạng Thái (0 -> 1 -> 2 hoặc 3)
                if (trangThaiMoi == 1) // ĐANG LÀM
                {
                    updateQuery = updateQuery.Set(x => x.MaNhanVienCheBien, maDauBep);
                    updateQuery = updateQuery.Set(x => x.ThoiGianDuKien, thoiGianDuKien);

                    // Chỉ gán thời gian bắt đầu nếu bếp nhận món lần đầu (chống ghi đè nếu bếp cập nhật lại dự kiến)
                    if (currentItem.ThoiGianBatDau == null)
                    {
                        updateQuery = updateQuery.Set(x => x.ThoiGianBatDau, now);
                    }
                }
                else if (trangThaiMoi == 2) // HOÀN THÀNH
                {
                    updateQuery = updateQuery.Set(x => x.MaNhanVienCheBien, maDauBep);
                    updateQuery = updateQuery.Set(x => x.ThoiGianHoanThanh, now);

                    // Xử lý nhảy cóc: Nếu Bếp từ trạng thái 0 bấm Hoàn thành luôn
                    if (currentItem.ThoiGianBatDau == null)
                {
                        updateQuery = updateQuery.Set(x => x.ThoiGianBatDau, now);
                    }
                }
                else if (trangThaiMoi == 3) // HỦY MÓN
                {
                    updateQuery = updateQuery.Set(x => x.MaNhanVienCheBien, maDauBep);
                    updateQuery = updateQuery.Set(x => x.GhiChuBep, ghiChu);
                    updateQuery = updateQuery.Set(x => x.ThoiGianHoanThanh, now); // Chốt ca để thống kê biết giờ bị hủy
                }

                // 4. Thực thi Update xuống Database
                await updateQuery.Update();

                // =====================================================================
                // 5. [THÊM MỚI] TỰ ĐỘNG TÍNH TOÁN TRẠNG THÁI CHO ĐƠN HÀNG MẸ
                // =====================================================================
                if (currentItem.MaDonHang != null)
                {
                    int maDonHang = currentItem.MaDonHang.Value;

                    // Kéo toàn bộ các món của đơn hàng này lên để "chấm điểm"
                    var allItemsRes = await DatabaseService.Client.From<CTDonHang>()
                        .Where(x => x.MaDonHang == maDonHang)
                        .Get();
                    var allItems = allItemsRes.Models;

                    if (allItems.Any())
                    {
                        int totalItems = allItems.Count;
                        int countHuy = allItems.Count(x => x.TrangThaiItem == 3);
                        int countHoanThanh = allItems.Count(x => x.TrangThaiItem == 2);
                        int countChoXacNhan = allItems.Count(x => x.TrangThaiItem == 0);

                        int trangThaiDonHangMoi = 0;

                        // Logic của Dũng:
                        // 1. Nếu tất cả đều hủy -> Đơn hàng Đã Hủy (3)
                        if (countHuy == totalItems)
                        {
                            trangThaiDonHangMoi = 3;
                        }
                        // 2. Nếu (Số món hoàn thành + Số món hủy) = Tổng số món -> Đơn hàng Hoàn Thành (2)
                        // (Tức là không còn món nào Đang chờ (0) hay Đang làm (1))
                        else if ((countHoanThanh + countHuy) == totalItems)
                        {
                            trangThaiDonHangMoi = 2;
                        }
                        // 3. Nếu tất cả là chờ xác nhận -> Đơn hàng Chờ xác nhận (0)
                        else if (countChoXacNhan == totalItems)
                        {
                            trangThaiDonHangMoi = 0;
                        }
                        // 4. Các trường hợp còn lại (Có ít nhất 1 món đang làm, hoặc lộn xộn chờ/làm/xong) -> Đang làm (1)
                        else
                        {
                            trangThaiDonHangMoi = 1;
                        }

                        // Cập nhật trạng thái mới cho bảng DonHang
                        // Cập nhật trạng thái mới cho bảng DonHang
                        await DatabaseService.Client.From<DonHang>()
                            .Where(x => x.MaDonHang == maDonHang)
                            .Set(x => x.TrangThai, trangThaiDonHangMoi)
                            .Update();

                        // =====================================================================
                        // 6. [THÊM MỚI] GỬI TIN NHẮN THÔNG BÁO KHI ĐƠN HÀNG VỪA HOÀN THÀNH
                        // Chỉ bắn 1 lần duy nhất tại thời điểm CHUYỂN sang trạng thái Hoàn thành (2),
                        // tránh bắn lại nếu món này gọi update lại trong khi đơn đã hoàn thành từ trước.
                        // =====================================================================
                        if (trangThaiMoi == 2 && currentItem.TrangThaiItem != 2)
                        {
                            try
                            {
                                // 6.1 Lấy tên bàn (DonHang -> BanAn)
                                var donHangRes = await DatabaseService.Client.From<DonHang>()
                                    .Where(x => x.MaDonHang == maDonHang)
                                    .Get();
                                var donHang = donHangRes.Models.FirstOrDefault();

                                string tenBan = "Không xác định";
                                if (donHang != null)
                                {
                                    var banAnRes = await DatabaseService.Client.From<BanAn>()
                                        .Where(x => x.MaBanAn == donHang.MaBanAn)
                                        .Get();
                                    var banAn = banAnRes.Models.FirstOrDefault();
                                    if (banAn != null) tenBan = banAn.TenBan;
                                }

                                // 6.2 Lấy tên của ĐÚNG CÁI MÓN vừa nấu xong (Menu)
                                var menuRes = await DatabaseService.Client.From<Menu>()
                                    .Where(x => x.MaMon == currentItem.MaMon)
                                    .Get();
                                var menu = menuRes.Models.FirstOrDefault();
                                string tenMon = menu != null ? menu.TenMon : "Món không xác định";

                                // 6.3 Tạo nội dung tin nhắn báo từng món (VD: 🔔 [Bàn 12] Tiramisu (x2) : ✅ Đã lên mâm!)
                                string content = $"🔔 [{tenBan}] {tenMon} (x{currentItem.SoLuong}) : ✅ HOÀN THÀNH!";

                                // 6.4 Tạo và lưu tin nhắn hệ thống (sender = đầu bếp vừa hoàn thành món)
                                var systemMsg = new TinNhan
                                {
                                    SenderId = maDauBep ?? 0, // ID Đầu bếp
                                    RecipientId = null,       // Broadcast cho mọi người (Phục vụ sẽ thấy)
                                    Content = content,
                                    Timestamp = DateTime.Now,
                                    IsRead = false
                                };

                                // 6.5 Phát tin nhắn realtime cho mọi client đang kết nối (ĐẨY VÀO LUỒNG NGẦM)
                                string normalizedJson = JsonConvert.SerializeObject(systemMsg);

                                // Dùng Task.Run để chạy ngầm, không làm kẹt luồng trả kết quả SUCCESS
                                Task.Run(async () =>
                                {
                                    await Task.Delay(200); // Nhường đường cho lệnh SUCCESS về đích trước
                                    await SocketServer.Broadcast("NEW_MESSAGE|" + normalizedJson);
                                });
                            }
                            catch (Exception notifyEx)
                            {
                                // Không để lỗi gửi thông báo làm hỏng luồng cập nhật món ăn chính
                                Console.WriteLine($"[KitchenService.Notify] Lỗi khi gửi tin nhắn hoàn thành đơn: {notifyEx.Message}");
                            }
                        }
                    }
                }

                return "SUCCESS|Cập nhật món ăn thành công!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KitchenService.Update] Error: {ex.Message}");
                return $"FAIL|Lỗi hệ thống khi cập nhật: {ex.Message}";
            }
        }

        public async Task<List<CTDonHang>> GetKitchenReportDataAsync(DateTime tuNgay, DateTime denNgay, int? maDauBep)
        {
            try
            {
                // Tối ưu hóa thời gian: Chuyển ngày bắt đầu về 00:00:00 và ngày kết thúc về 23:59:59 để so sánh chỉ ngày
                DateTime startOfDay = tuNgay.Date;
                DateTime endOfDay = denNgay.Date.AddDays(1).AddTicks(-1);

                // Khởi tạo truy vấn cơ bản lọc theo khoảng thời gian bắt đầu làm món
                var query = DatabaseService.Client
                    .From<CTDonHang>()
                    .Where(x => x.ThoiGianBatDau >= startOfDay)
                    .Where(x => x.ThoiGianBatDau <= endOfDay);

                // Nếu người dùng chọn một đầu bếp cụ thể (maDauBep > 0), lọc theo đúng mã đầu bếp đó
                // Nếu maDauBep == 0 (Tất cả đầu bếp), ta chỉ cần lấy những dòng mà MaNhanVienCheBien KHÔNG BỊ NULL
                if (maDauBep.HasValue && maDauBep.Value > 0)
                {
                    query = query.Where(x => x.MaNhanVienCheBien == maDauBep.Value);
                }
                else
                {
                    query = query.Where(x => x.MaNhanVienCheBien != null);
                }

                var res = await query.Get();
                return res.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KitchenService] Error in GetKitchenReportDataAsync: {ex.Message}");
                return new List<CTDonHang>();
            }
        }

        public async Task<List<BepOrderDTO>> GetKitchenOrdersAsync()
        {
            var result = new List<BepOrderDTO>();
            try
            {
                // Kéo data thô
                var dhRes = await DatabaseService.Client.From<DonHang>().Get();
                var ctRes = await DatabaseService.Client.From<CTDonHang>().Get();
                var banRes = await DatabaseService.Client.From<BanAn>().Get();

                var dhList = dhRes.Models ?? new List<DonHang>();
                var ctList = ctRes.Models ?? new List<CTDonHang>();
                var banList = banRes.Models ?? new List<BanAn>();

                // Lọc đơn hàng: 0 (Chờ xác nhận), 1 (Đang chế biến)
                var activeOrders = dhList.Where(d => d.TrangThai == 0 || d.TrangThai == 1).ToList();

                foreach (var dh in activeOrders)
                {
                    // Lấy Tên bàn
                    var ban = banList.FirstOrDefault(b => b.MaBanAn == dh.MaBanAn);
                    string tenBan = ban != null ? ban.TenBan : "Mang về";

                    // Trạng thái
                    string trangThaiStr = dh.TrangThai == 0 ? "Chờ xác nhận" : "Đang chế biến";

                    // Cộng dồn món và kiểm tra món ưu tiên
                    var ctCuaDon = ctList.Where(c => c.MaDonHang == dh.MaDonHang).ToList();
                    int tongMon = ctCuaDon.Sum(c => c.SoLuong);
                    bool coUuTien = ctCuaDon.Any(c => c.UuTien);

                    result.Add(new BepOrderDTO
                    {
                        MaDonHang = dh.MaDonHang,
                        TenBan = tenBan,
                        ThoiGianDat = dh.NgayOrder,
                        SoLuongMon = tongMon,
                        TrangThai = trangThaiStr,
                        UuTien = coUuTien ? 1 : 0
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("LỖI KHI LẤY ĐƠN BẾP: " + ex.Message);
            }
            return result;
        }

        // Hàm quét ngầm kiểm tra món ăn quá giờ (SLA Tracker)
        public async Task<bool> AutoScanPriorityItemsAsync(int maxMinutes)
        {
            try
            {
                bool hasChanges = false;
                DateTime now = DateTime.Now;

                // 1. Kéo các Đơn hàng đang mở (0 hoặc 1) để lấy gốc thời gian (NgayOrder)
                var dhRes = await DatabaseService.Client.From<DonHang>()
                    .Where(x => x.TrangThai == 0 || x.TrangThai == 1)
                    .Get();
                var activeOrders = dhRes.Models;

                if (!activeOrders.Any()) return false;

                // 2. Kéo các Chi tiết món đang Chờ (0) hoặc Đang làm (1) và CHƯA ƯU TIÊN
                var ctRes = await DatabaseService.Client.From<CTDonHang>().Get();
                var pendingItems = ctRes.Models
                    .Where(x => (x.TrangThaiItem == 0 || x.TrangThaiItem == 1)
                             && x.UuTien == false
                             && x.MaDonHang != null)
                    .ToList();

                // 3. Quét và so sánh thời gian
                foreach (var item in pendingItems)
                {
                    var parentOrder = activeOrders.FirstOrDefault(o => o.MaDonHang == item.MaDonHang);

                    // Chỉ cần kiểm tra parentOrder khác null là đủ an toàn
                    if (parentOrder != null)
                    {
                        // Vì NgayOrder là DateTime thường, ta dùng thẳng luôn không cần .Value
                        double minutesWaited = (now - parentOrder.NgayOrder).TotalMinutes;

                        // Nếu đợi lâu hơn mức quy định -> Ép thành Ưu Tiên
                        if (minutesWaited >= maxMinutes)
                        {
                            await DatabaseService.Client.From<CTDonHang>()
                                .Where(x => x.MaCT == item.MaCT)
                                .Set(x => x.UuTien, true)
                                .Update();

                            hasChanges = true; // Bật cờ báo hiệu có sự thay đổi
                        }
                    }
                }

                return hasChanges;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SLA Tracker Error]: {ex.Message}");
                return false;
            }
        }
    }
}
