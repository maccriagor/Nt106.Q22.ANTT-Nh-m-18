using CafeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CafeServer.Services
{
    public class BillService
    {
        public async Task<List<HoaDon>> GetAllAsync()
        {
            try
            {
                var res = await DatabaseService.Client
                    .From<HoaDon>()
                    .Order(x => x.NgayTao, Ordering.Descending) // Hóa đơn mới nhất lên đầu
                    .Get();
                return res.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BillService] Error: {ex.Message}");
                return new List<HoaDon>();
            }
        }

        public async Task<HoaDon> GetActiveBillByTableAsync(int tableId)
        {
            try
            {
                var res = await DatabaseService.Client.From<HoaDon>()
                    .Where(x => x.MaBanAn == tableId)
                    .Where(x => x.TrangThai == "Chưa thanh toán")
                    .Get();

                return res.Models.FirstOrDefault();
            }
            catch { return null; }
        }
    }
}
