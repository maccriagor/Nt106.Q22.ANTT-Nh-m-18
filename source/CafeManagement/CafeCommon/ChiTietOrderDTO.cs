using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    public class ChiTietOrderDTO
    {
        // 1. Khóa chính và liên kết
        public int MaCT { get; set; }
        public int MaDonHang { get; set; }

        // 2. Thông tin hiển thị (Đã được Server dịch từ ID sang Tên)
        public string TenMon { get; set; }
        public string TenBan { get; set; }
        public string TenNVOrder { get; set; }

        // 3. Chi tiết món ăn
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public bool UuTien { get; set; }

        // 4. Ghi chú
        public string GhiChuKhach { get; set; }
        public string GhiChuBep { get; set; }

        // 5. Trạng thái và nhân viên Bếp
        public int TrangThaiItem { get; set; }
        public int? MaNhanVienCheBien { get; set; } // ID đầu bếp nhận làm

        // 6. Thời gian quản lý
        public DateTime? NgayOrder { get; set; } // Thời gian Waiter bấm gửi
        public DateTime? ThoiGianBatDau { get; set; } // Bếp đổi sang Đang làm (1)
        public DateTime? ThoiGianHoanThanh { get; set; } // Bếp đổi sang Hoàn thành (2)
        public int? ThoiGianDuKien { get; set; }

        // =========================================================
        // THUỘC TÍNH MỞ RỘNG (Dùng để hiển thị lên DataGridView cho đẹp)
        // =========================================================
        public string GioDatMon => NgayOrder.HasValue ? NgayOrder.Value.ToString("HH:mm") : "";

        public string TenTrangThai
        {
            get
            {
                switch (TrangThaiItem)
                {
                    case 0: return "Chờ xác nhận";
                    case 1: return "Đang làm";
                    case 2: return "Hoàn thành";
                    case 3: return "Đã hủy";
                    default: return "Chưa rõ";
                }
            }
        }

        public string LoaiUuTien => UuTien ? "Ưu tiên" : "Bình thường";
    }
}
