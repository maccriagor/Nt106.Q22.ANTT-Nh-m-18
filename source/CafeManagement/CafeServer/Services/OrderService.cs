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
                    // Chuyển trạng thái bàn sang "Có khách"
                    await DatabaseService.Client.From<BanAn>()
                        .Where(x => x.MaBanAn == order.MaBanAn)
                        .Set(x => x.TrangThai, "Có khách")
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
    }
}