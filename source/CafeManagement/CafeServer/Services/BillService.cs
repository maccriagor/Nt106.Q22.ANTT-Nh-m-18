using CafeCommon;
using System;
using System.Threading.Tasks;
using Supabase.Postgrest;
using Supabase;

namespace CafeServer.Services
{
    public class BillService
    {
        public static async Task<bool> ValidateBillExistence(Bill bill)
        {
            // Now these will work because 'Employee', 'Table', and 'Order' exist in CafeCommon
            bool employeeExists = await DatabaseService.CheckExistsAsync<CafeCommon.Employee>("MaNV", bill.MaNV);
            bool tableExists = await DatabaseService.CheckExistsAsync<CafeCommon.Table>("MaBanAn", bill.MaBanAn);
            bool orderExists = await DatabaseService.CheckExistsAsync<CafeCommon.Order>("MaDonhang", bill.MaDonhang);

            // Optional: Check Customer if it's not null
            bool customerExists = true;
            if (bill.MaKH.HasValue)
            {
                customerExists = await DatabaseService.CheckExistsAsync<CafeCommon.KhachHang>("MaKH", bill.MaKH.Value);
            }

            return employeeExists && tableExists && orderExists && customerExists;
        }

        public static async Task<KhuyenMai> GetCouponInfo(int maKM)
        {
            // Using the .Filter method is often safer for static typing in Supabase C#
            var result = await DatabaseService.Client.From<KhuyenMai>()
                                .Filter("MaKM", Constants.Operator.Equals, maKM)
                                .Single();
            return result;
        }
        public static async Task<List<Bill>> AdvancedSearch(string maHD, string maNV, string maBan, string date)
        {
            // Start the query
            var query = DatabaseService.Client.From<Bill>();

            // Chain the filters directly
            if (maHD != "NONE") query.Filter("MaHD", Constants.Operator.Equals, int.Parse(maHD));
            if (maNV != "NONE") query.Filter("MaNV", Constants.Operator.Equals, int.Parse(maNV));
            if (maBan != "NONE") query.Filter("MaBanAn", Constants.Operator.Equals, int.Parse(maBan));

            // Date range
            query.Filter("NgayTao", Constants.Operator.GreaterThanOrEqual, date + " 00:00:00")
                 .Filter("NgayTao", Constants.Operator.LessThanOrEqual, date + " 23:59:59");

            // Execute
            var result = await query.Get();
            return result.Models;
        }
    }
}