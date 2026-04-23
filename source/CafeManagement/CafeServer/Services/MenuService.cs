using CafeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeServer.Services
{
    public class MenuService
    {
        // 1. Lấy toàn bộ danh sách món ăn
        public async Task<List<Menu>> GetAllMenuAsync()
        {
            var result = await DatabaseService.Client.From<Menu>().Get();
            return result.Models;
        }

        // 2. Thêm món mới
        public async Task<string> AddMenuAsync(Menu item)
        {
            try
            {
                // Kiểm tra xem tên món đã tồn tại trong Database chưa
                var existing = await DatabaseService.Client.From<Menu>()
                                        .Where(x => x.TenMon == item.TenMon)
                                        .Get();

                if (existing.Models.Count > 0)
                {
                    // Trả về mã lỗi riêng để Client dễ bắt
                    return "ADD_MENU_FAIL|Tên món ăn này đã có trong thực đơn rồi!";
                }

                // Nếu chưa trùng thì mới Insert
                await DatabaseService.Client.From<Menu>().Insert(item);
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "ERROR|" + ex.Message;
            }
        }

        // 3. Cập nhật món ăn
        public async Task<bool> UpdateMenuAsync(Menu item)
        {
            try
            {
                await DatabaseService.Client.From<Menu>()
                    .Where(x => x.MaMon == item.MaMon)
                    .Update(item);
                return true;
            }
            catch { return false; }
        }

        // 4. Xóa món ăn
        public async Task<bool> DeleteMenuAsync(int id)
        {
            try
            {
                await DatabaseService.Client.From<Menu>().Where(x => x.MaMon == id).Delete();
                return true;
            }
            catch { return false; }
        }

        // 5. Tìm kiếm theo tên món
        public async Task<List<Menu>> SearchMenuByNameAsync(string name)
        {
            var result = await DatabaseService.Client.From<Menu>()
                .Filter("tenmon", Supabase.Postgrest.Constants.Operator.ILike, $"%{name}%") //tìm kiếm không phân biệt chữ hoa và thường
                .Get();
            return result.Models;
        }

        public async Task<List<LoaiMon>> GetAllCategoriesAsync()
        {
            var result = await DatabaseService.Client.From<LoaiMon>().Get();
            return result.Models;
        }
    }
}
