using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeCommon;
using System;
using static Supabase.Postgrest.Constants;

namespace CafeServer.Services
{
    public class KitchenService
    {

        public async Task<List<UserAccount>> GetKitchenStaffAsync()
        {
            try
            {
                var res = await DatabaseService.Client
                    .From<UserAccount>()
                    .Where(x => x.VaiTro == "Kitchen")
                    .Order(x => x.HoTen, Ordering.Ascending) // Sắp xếp theo tên từ A-Z cho dễ nhìn
                    .Get();

                return res.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KitchenService] Error in GetKitchenStaffAsync: {ex.Message}");
                return new List<UserAccount>();
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
    }
}