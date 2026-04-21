using CafeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeServer.Services
{
    public class RevenueService
    {
        public async Task<List<RevenueByTableDTO>> GetRevenueByTableAsync(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DateTime endOfDay = toDate.Date.AddDays(1).AddTicks(-1);
                // 1. Lấy tất cả hóa đơn đã thanh toán trong khoảng thời gian
                var result = await DatabaseService.Client.From<HoaDon>()
                    .Where(x => x.NgayTao >= fromDate && x.NgayTao <= endOfDay)
                    .Where(x => x.TrangThai == "Đã thanh toán")
                    .Get();

                var listHoaDon = result.Models;

                // 2. Lấy danh sách bàn để lấy Tên Bàn (Join)
                var tables = await DatabaseService.Client.From<BanAn>().Get();
                var listBan = tables?.Models ?? new List<BanAn>();

                // 3. Dùng LINQ để nhóm và tính toán
                var report = listHoaDon
                    .GroupBy(h => h.MaBanAn)
                    .Select(g => {
                        var ban = listBan.FirstOrDefault(b => b.MaBanAn == g.Key);
                        return new RevenueByTableDTO
                        {
                            MaBanAn = (int)g.Key,
                            TenBan = ban?.TenBan ?? "Mang về",
                            SoLuongHoaDon = g.Count(),
                            DoanhThu = g.Sum(h => h.ThanhTien),
                            HoaDonLonNhat = g.Max(h => h.ThanhTien),
                            HoaDonNhoNhat = g.Min(h => h.ThanhTien),
                            DoanhThuTB = g.Average(h => h.ThanhTien)
                        };
                    }).ToList();

                return report;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"LỖI THỐNG KÊ: " + ex.Message);
                return new List<RevenueByTableDTO>();
            }
        }
    }
}
