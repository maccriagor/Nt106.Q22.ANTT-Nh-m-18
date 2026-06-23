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
            catch (Exception ex)
            {
                Console.WriteLine($"[TableService.AddAsync] Exception: {ex}");
                return false;
            }
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
            catch (Exception ex)
            {
                Console.WriteLine($"[TableService.UpdateAsync] Exception: {ex}");
                return false;
            }
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

        public async Task<bool> UpdateStatusAsync(int maBan, string trangThai)
        {
            try
            {
                await DatabaseService.Client.From<BanAn>()
                    .Where(x => x.MaBanAn == maBan)
                    .Set(x => x.TrangThai, trangThai)
                    .Update();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TableService] Error: {ex.Message}");
                return false;
            }
        }


        // Logic chuyển bàn
        public async Task<bool> TransferTableAsync(int fromTableId, int toTableId)
        {
            try
            {
                // 1. Dựa vào HoaDon để tìm hóa đơn chưa thanh toán của bàn cũ
                var billRes = await DatabaseService.Client.From<HoaDon>()
                    .Where(x => x.MaBanAn == fromTableId && x.TrangThai == "Chưa thanh toán")
                    .Get();
                var activeBill = billRes.Models.FirstOrDefault();

                // Nếu không có hóa đơn nào chưa thanh toán -> Bàn này đang trống, không cần chuyển
                if (activeBill == null) return false;

                int currentMaDonHang = activeBill.MaDonHang;

                // 2. Sửa mã bàn ăn trong HÓA ĐƠN sang bàn mới
                await DatabaseService.Client.From<HoaDon>()
                    .Where(x => x.MaHD == activeBill.MaHD)
                    .Set(x => x.MaBanAn, toTableId)
                    .Update();

                // 3. Sửa mã bàn ăn trong ĐƠN HÀNG tương ứng sang bàn mới
                await DatabaseService.Client.From<DonHang>()
                    .Where(x => x.MaDonHang == currentMaDonHang)
                    .Set(x => x.MaBanAn, toTableId)
                    .Update();

                // 4. Đổi trạng thái 2 bàn trong DB (Dùng hàm gộp UpdateStatusAsync của bạn)
                await UpdateStatusAsync(fromTableId, "Trống");
                await UpdateStatusAsync(toTableId, "Có khách");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TRANSFER ERROR]: {ex.Message}");
                return false;
            }
        }

        //// 3. Chuyển bàn
        //public async Task<bool> TransferTableAsync(int fromTableId, int toTableId)
        //{
        //    try
        //    {
        //        // 1. Tìm hóa đơn chưa thanh toán
        //        var res = await DatabaseService.Client.From<HoaDon>()
        //            .Where(x => x.MaBanAn == fromTableId && x.TrangThai == "Chưa thanh toán")
        //            .Get();
        //        var bill = res.Models.FirstOrDefault();

        //        // 2. Lấy thông tin trạng thái bàn cũ để mang sang bàn mới
        //        var tableRes = await DatabaseService.Client.From<BanAn>().Where(x => x.MaBanAn == fromTableId).Get();
        //        var oldTable = tableRes.Models.FirstOrDefault();
        //        string statusToMove = oldTable?.TrangThai ?? "Có khách";

        //        if (bill != null)
        //        {
        //            // Nếu có hóa đơn, cập nhật MaBanAn trên hóa đơn đó
        //            await DatabaseService.Client.From<HoaDon>()
        //                .Where(x => x.MaHD == bill.MaHD)
        //                .Set(x => x.MaBanAn, toTableId)
        //                .Update();
        //            Console.WriteLine($"[OrderService] Đã chuyển MaHD {bill.MaHD} sang bàn {toTableId}");
        //        }

        //        // 3. Cập nhật trạng thái cho cả 2 bàn
        //        await ServiceManager.Table.UpdateStatusAsync(fromTableId, "Trống");
        //        await ServiceManager.Table.UpdateStatusAsync(toTableId, statusToMove);

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"[OrderService.TransferTableAsync] Error: {ex.Message}");
        //        return false;
        //    }
        //}

        
    }
}
