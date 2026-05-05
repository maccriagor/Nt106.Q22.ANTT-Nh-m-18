using CafeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CafeServer.Services
{
    public class KhachHangService
    {
        public async Task<List<KhachHang>> GetAllAsync()
        {
            try
            {
                var res = await DatabaseService.Client
                    .From<KhachHang>()
                    // Ordering by NgayDangKy descending so the newest customers appear at the top
                    .Order(x => x.NgayDangKy, Ordering.Descending)
                    .Get();

                return res.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CustomerService] Error: {ex.Message}");
                return new List<KhachHang>();
            }
        }


        public async Task<bool> AddAsync(KhachHang kh)
        {
            try
            {
                // Supabase Insert logic
                var result = await DatabaseService.Client.From<KhachHang>().Insert(kh);
                return result.Models.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CustomerService] Insert Error: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                // Matches the ID in the 'makh' column and deletes that row
                await DatabaseService.Client
                    .From<KhachHang>()
                    .Where(x => x.MaKH == id)
                    .Delete();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CustomerService] Delete Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(KhachHang kh)
        {
            try
            {
                // This will update all columns for the row where makh matches kh.MaKH
                var result = await DatabaseService.Client
                    .From<KhachHang>()
                    .Update(kh);

                return result.Models.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CustomerService] Update Error: {ex.Message}");
                return false;
            }
        }
    }
}