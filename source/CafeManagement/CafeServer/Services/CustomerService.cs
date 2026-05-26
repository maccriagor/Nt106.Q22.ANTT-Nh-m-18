using CafeCommon;
using System.Threading.Tasks;

namespace CafeServer.Services
{
    public class CustomerService
    {
        public async Task<KhachHang> GetCustomerByPhoneAsync(string phone)
        {
            try
            {
                var result = await DatabaseService.Client
                    .From<KhachHang>()
                    .Filter("sdt", Supabase.Postgrest.Constants.Operator.Equals, phone)
                    .Get();

                return result.Models.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] CustomerService: {ex.Message}");
                return null;
            }
        }
        public async Task<KhachHang> GetCustomerByIdAsync(int maKH)
        {
            try
            {
                var result = await DatabaseService.Client
                    .From<KhachHang>()
                    .Filter("makh", Supabase.Postgrest.Constants.Operator.Equals, maKH)
                    .Get();

                return result.Models.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] GetCustomerById {maKH}: {ex.Message}");
                return null;
            }
        }
    }
}