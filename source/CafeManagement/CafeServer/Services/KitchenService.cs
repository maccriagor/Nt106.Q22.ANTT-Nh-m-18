using CafeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    .Get();
                return res.Models ?? new List<UserAccount>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KitchenService] Error: {ex.Message}");
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
                    updateQuery = updateQuery.Set(x => x.ThoiGianHoanThanh, now);

                    // Xử lý nhảy cóc: Nếu Bếp từ trạng thái 0 bấm Hoàn thành luôn
                    if (currentItem.ThoiGianBatDau == null)
                    {
                        updateQuery = updateQuery.Set(x => x.ThoiGianBatDau, now);
                    }
                }
                else if (trangThaiMoi == 3) // HỦY MÓN
                {
                    updateQuery = updateQuery.Set(x => x.GhiChuBep, ghiChu);
                    updateQuery = updateQuery.Set(x => x.ThoiGianHoanThanh, now); // Chốt ca để thống kê biết giờ bị hủy
                }

                // 4. Thực thi Update xuống Database
                await updateQuery.Update();

                return "SUCCESS|Cập nhật món ăn thành công!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KitchenService.Update] Error: {ex.Message}");
                return $"FAIL|Lỗi hệ thống khi cập nhật: {ex.Message}";
            }
        }
    }
}
