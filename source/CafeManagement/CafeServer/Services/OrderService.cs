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