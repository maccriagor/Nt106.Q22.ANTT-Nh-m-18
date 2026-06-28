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
    public class OrderService
    {

        public async Task<List<dynamic>> GetAllOrdersExtendedAsync()
        {
            try
            {
                var res = await DatabaseService.Client
                    .From<DonHang>()
                    // We add 'ctdonhang(soluong)' to the select string
                    .Select("madonhang, trangthai, ngayorder, banan(tenban), hoadon(mahd), ctdonhang(soluong)")
                    .Get();

                if (string.IsNullOrEmpty(res.Content)) return new List<dynamic>();
                return JsonConvert.DeserializeObject<List<dynamic>>(res.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrderService] Error: {ex.Message}");
                return new List<dynamic>();
            }
        }

        public async Task<bool> SubmitOrderAsync(DonHang order, List<CTDonHang> details)
        {
            int step = 0;
            try
            {
                step = 1;
                // 1. Tìm xem bàn này hiện tại có HÓA ĐƠN nào chưa thanh toán không
                var existingBillRes = await DatabaseService.Client.From<HoaDon>()
                    .Where(x => x.MaBanAn == order.MaBanAn && x.TrangThai == "Chưa thanh toán")
                    .Get();
                var activeBill = existingBillRes.Models.FirstOrDefault();

                int finalMaDonHang = 0;

                if (activeBill == null)
                {
                    step = 2;
                    // ========================================================
                    // TRƯỜNG HỢP 1: GỬI ORDER LẦN ĐẦU (Chưa có hóa đơn treo)
                    // ========================================================
                    // Tạo đơn hàng mới
                    var newOrderResult = await DatabaseService.Client.From<DonHang>().Insert(order);
                    var createdOrder = newOrderResult.Models.FirstOrDefault();
                    if (createdOrder == null) return false;

                    finalMaDonHang = createdOrder.MaDonHang;

                    step = 3;
                    // Tạo hóa đơn mới ăn theo MaDonHang vừa sinh ra
                    var newBill = new HoaDon
                    {
                        MaDonHang = finalMaDonHang,
                        MaBanAn = order.MaBanAn,
                        MaNV = order.MaNVOrder,
                        NgayTao = DateTime.Now,
                        TongTien = 0,   // Sẽ tính toán ở bước sau
                        ThanhTien = 0,
                        TrangThai = "Chưa thanh toán"
                    };
                    await DatabaseService.Client.From<HoaDon>().Insert(newBill);

                    step = 4;
                    // Chuyển trạng thái bàn sang "Có khách" VÀ GÁN LUÔN NHÂN VIÊN PHỤC VỤ CHO BÀN NÀY
                    await DatabaseService.Client.From<BanAn>()
                        .Where(x => x.MaBanAn == order.MaBanAn)
                        .Set(x => x.TrangThai, "Có khách")
                        .Set(x => x.MaNhanVien, order.MaNVOrder)
                        .Update();
                }
                else
                {
                    // ========================================================
                    // TRƯỜNG HỢP 2: KHÁCH GỌI THÊM MÓN (Đã có hóa đơn treo)
                    // ========================================================
                    finalMaDonHang = activeBill.MaDonHang; // Lấy luôn MaDonHang cũ ra dùng tiếp
                }

                step = 5;
                // 2. Xử lý thêm/bớt món trong CTDonHang (Giữ nguyên logic vòng lặp cũ)
                foreach (var detail in details)
                {
                    detail.MaDonHang = finalMaDonHang;

                    var existingDetailRes = await DatabaseService.Client.From<CTDonHang>()
                        .Where(x => x.MaDonHang == finalMaDonHang && x.MaMon == detail.MaMon)
                        .Get();
                    var activeDetail = existingDetailRes.Models.FirstOrDefault();

                    if (activeDetail != null)
                    {
                        int newQty = activeDetail.SoLuong + detail.SoLuong;
                        if (newQty <= 0)
                        {
                            await DatabaseService.Client.From<CTDonHang>().Where(x => x.MaCT == activeDetail.MaCT).Delete();
                        }
                        else
                        {
                            await DatabaseService.Client.From<CTDonHang>()
                                .Where(x => x.MaCT == activeDetail.MaCT)
                                .Set(x => x.SoLuong, newQty)
                                .Update();
                        }
                    }
                    else if (detail.SoLuong > 0)
                    {
                        await DatabaseService.Client.From<CTDonHang>().Insert(detail);
                    }
                }

                step = 6;
                // 3. ĐỒNG BỘ TIỀN VÀO HÓA ĐƠN
                var allDetailsRes = await DatabaseService.Client.From<CTDonHang>()
                    .Where(x => x.MaDonHang == finalMaDonHang)
                    .Get();
                var allDetails = allDetailsRes.Models;

                decimal totalOrderAmount = allDetails.Sum(d => d.SoLuong * d.DonGia);

                // Cập nhật lại số tiền mới nhất vào Hóa đơn dựa trên MaDonHang
                await DatabaseService.Client.From<HoaDon>()
                    .Where(x => x.MaDonHang == finalMaDonHang)
                    .Set(x => x.TongTien, totalOrderAmount)
                    .Set(x => x.ThanhTien, totalOrderAmount)
                    .Update();

                // =====================================================================
                // 7. [THÊM MỚI] GỬI TIN NHẮN THÔNG BÁO CHO TẤT CẢ NHÂN VIÊN
                // =====================================================================
                try
                {
                    // 7.1 Lấy Tên Bàn
                    var banAnRes = await DatabaseService.Client.From<BanAn>()
                        .Where(x => x.MaBanAn == order.MaBanAn).Get();
                    string tenBan = banAnRes.Models.FirstOrDefault()?.TenBan ?? $"Bàn {order.MaBanAn}";

                    // 7.2 Lấy Tên Nhân viên Order
                    var nvRes = await DatabaseService.Client.From<UserAccount>()
                        .Where(x => x.MaNguoiDung == order.MaNVOrder).Get();
                    string tenNV = nvRes.Models.FirstOrDefault()?.HoTen ?? $"NV {order.MaNVOrder}";

                    // 7.3 Tính tổng số lượng món vừa gửi
                    int tongSoMon = details.Sum(d => d.SoLuong);

                    // 7.4 Định dạng giá tiền (Ví dụ: 150,000đ)
                    string giaTien = totalOrderAmount.ToString("N0") + "đ";

                    // 7.5 Phân loại thông minh: Là Đơn mới hay Gọi thêm món?
                    string loaiDon = activeBill == null ? "ĐƠN MỚI" : "GỌI THÊM MÓN";

                    // 7.6 Ghép chuỗi theo đúng Format bạn yêu cầu: [thời gian]Tên: ĐƠN MỚI [Bàn 4]: 3 món - (Giá tiền)
                    string timeString = DateTime.Now.ToString("HH:mm");
                    string content = $"🔔 [{timeString}] {tenNV}: {loaiDon} [{tenBan}] - {tongSoMon} món {giaTien}";

                    // 7.7 Khởi tạo và Lưu tin nhắn
                    var systemMsg = new TinNhan
                    {
                        SenderId = order.MaNVOrder,
                        RecipientId = null, // Gửi Broadcast cho tất cả mọi người
                        Content = content,
                        Timestamp = DateTime.Now,
                        IsRead = false
                    };

                    await ServiceManager.User.SaveMessageToDatabase(systemMsg);

                    // 7.8 Bắn tín hiệu Realtime qua Socket
                    string normalizedJson = Newtonsoft.Json.JsonConvert.SerializeObject(systemMsg);

                    // Dùng hàm Broadcast của SocketServer để đẩy cho tất cả Client
                    await SocketServer.Broadcast("NEW_MESSAGE|" + normalizedJson);
                }
                catch (Exception notifyEx)
                {
                    Console.WriteLine($"[OrderService.Notify] Lỗi gửi thông báo Đơn mới: {notifyEx.Message}");
                }

                return true;
            }
            catch (Exception ex)
            {
                // Ghi nhận log siêu chi tiết ra Console của Server để Dũng nhìn thấy ngay vị trí lỗi
                Console.WriteLine($"==================================================");
                Console.WriteLine($"[LỖI SUBMIT_ORDER] Thất bại tại BƯỚC SỐ: {step}");
                Console.WriteLine($"[CHI TIẾT LỖI DB]: {ex.Message}");
                Console.WriteLine($"==================================================");
                return false;
            }
        }


        public async Task<List<dynamic>> GetOrderDetailsExtendedAsync(int orderId)
        {
            try
            {
                var res = await DatabaseService.Client
                    .From<CTDonHang>()
                    .Filter("madonhang", Operator.Equals, orderId)
                    // UPDATED: Just select tenmon straight from the menu relation
                    .Select("soluong, ghichukhach, ghichubep, trangthaiitem, menu(mamon, tenmon)")
                    .Get();

                if (string.IsNullOrEmpty(res.Content)) return new List<dynamic>();
                return JsonConvert.DeserializeObject<List<dynamic>>(res.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrderService] GetDetails Error: {ex.Message}");
                return new List<dynamic>();
            }
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            try
            {
                // 1. Delete details first to avoid Foreign Key conflicts
                await DatabaseService.Client
                    .From<CTDonHang>()
                    .Where(x => x.MaDonHang == orderId)
                    .Delete();

                // 2. Delete the main order
                await DatabaseService.Client
                    .From<DonHang>()
                    .Where(x => x.MaDonHang == orderId)
                    .Delete();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrderService] Delete Error: {ex.Message}");
                return false;
            }
        }

        public async Task<List<string>> GetUniqueTableNamesAsync()
        {
            try
            {
                // 1. Fetch both mabanan (for sorting consistency if needed) and tenban
                var res = await DatabaseService.Client
                    .From<BanAn>()
                    .Select("mabanan, tenban")
                    .Get();

                if (string.IsNullOrEmpty(res.Content) || res.Content == "[]")
                    return new List<string>();

                var list = JsonConvert.DeserializeObject<List<BanAn>>(res.Content);

                // 2. Extract the actual name column, sorting cleanly by ID
                return list
                    .OrderBy(x => x.MaBanAn)
                    .Select(x => x.TenBan)
                    .Where(name => !string.IsNullOrEmpty(name))
                    .Distinct()
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrderService Error]: {ex.Message}");
                return new List<string>();
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


    }
}