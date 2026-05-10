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
                // FIX: The error log suggested the table is called 'menu' instead of 'mon'.
                // We go: CTDonHang -> Menu -> LoaiMon(tenloai)
                // If your table is actually named 'menu', use this:
                var res = await DatabaseService.Client
                    .From<CTDonHang>()
                    .Filter("madonhang", Operator.Equals, orderId)
                    .Select("soluong, ghichukhach, ghichubep, trangthaiitem, menu(loaimon(tenloai))")
                    .Get();

                if (string.IsNullOrEmpty(res.Content)) return new List<dynamic>();
                return JsonConvert.DeserializeObject<List<dynamic>>(res.Content);
            }
            catch (Exception ex)
            {
                // If 'menu' still fails, it means the Foreign Key for 'mamon' 
                // isn't set up in the Supabase Dashboard for the 'ctdonhang' table.
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

        public async Task<List<int>> GetUniqueTableNumbersAsync()
        {
            try
            {
                var res = await DatabaseService.Client
                    .From<DonHang>()
                    .Select("mabanan")
                    .Get();

                // Check if content is actually there
                if (string.IsNullOrEmpty(res.Content) || res.Content == "[]")
                    return new List<int>();

                // We deserialize to a list of the model to get the properties correctly
                var list = JsonConvert.DeserializeObject<List<DonHang>>(res.Content);

                return list
                    .Select(x => x.MaBanAn)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrderService Error]: {ex.Message}");
                return new List<int>();
            }
        }
    }
}