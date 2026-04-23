using CafeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeServer.Services
{
    public class DiscountService
    {
        

        // Lấy danh sách
        public async Task<List<KhuyenMaiDTO>> GetAllAsync()
        {
            // 1. Lấy dữ liệu Entity từ Supabase
            var result = await DatabaseService.Client.From<KhuyenMai>().Get();

            // 2. Sử dụng LINQ để map sang DTO
            var dtoList = result.Models.Select(km => new KhuyenMaiDTO
            {
                MaKM = km.MaKM,
                CodeKM = km.CodeKM,
                MoTa = km.MoTa,
                LoaiKM = km.LoaiKM,
                GiaTriGiam = km.GiaTriGiam,
                NgayBatDau = km.NgayBatDau,
                NgayHetHan = km.NgayHetHan,
                TrangThai = km.TrangThai
            }).ToList();

            return dtoList;
        }

        // Thêm mới
        public async Task<bool> AddAsync(KhuyenMai km)
        {
            try
            {
                await DatabaseService.Client.From<KhuyenMai>().Insert(km);
                return true;
            }
            catch { return false; }
        }

        // Cập nhật
        public async Task<bool> UpdateAsync(KhuyenMai km)
        {
            try
            {
                await DatabaseService.Client.From<KhuyenMai>()
                    .Where(x => x.MaKM == km.MaKM)
                    .Update(km);
                return true;
            }
            catch { return false; }
        }

        // Xóa
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await DatabaseService.Client.From<KhuyenMai>()
                    .Where(x => x.MaKM == id)
                    .Delete();
                return true;
            }
            catch { return false; }
        }
    }
}
