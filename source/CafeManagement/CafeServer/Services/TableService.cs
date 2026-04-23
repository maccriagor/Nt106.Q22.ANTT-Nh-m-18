using CafeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeServer.Services
{
    public class TableService
    {
        public async Task<List<BanAn>> GetAllAsync()
        {
            var res = await DatabaseService.Client.From<BanAn>().Get();
            return res.Models;
        }

        public async Task<bool> AddAsync(BanAn ban)
        {
            try
            {
                await DatabaseService.Client.From<BanAn>().Insert(ban);
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> UpdateAsync(BanAn ban)
        {
            try
            {
                // Admin chỉ được sửa Tên bàn và Số chỗ ngồi
                await DatabaseService.Client.From<BanAn>()
                    .Where(x => x.MaBanAn == ban.MaBanAn)
                    .Set(x => x.TenBan, ban.TenBan)
                    .Set(x => x.SoChoNgoi, ban.SoChoNgoi)
                    .Update();
                return true;
            }
            catch { return false; }
        }

        public async Task<string> DeleteAsync(int id)
        {
            // Kiểm tra trạng thái trước khi xóa
            var res = await DatabaseService.Client.From<BanAn>().Where(x => x.MaBanAn == id).Get();
            var ban = res.Models.FirstOrDefault();

            if (ban == null) return "FAIL|Bàn không tồn tại";
            if (ban.TrangThai != "Trống") return "FAIL|Chỉ được xóa bàn đang Trống!";

            await DatabaseService.Client.From<BanAn>().Where(x => x.MaBanAn == id).Delete();
            return "SUCCESS|Xóa thành công";
        }
    }
}
