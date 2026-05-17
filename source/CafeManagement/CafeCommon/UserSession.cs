using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    public static class UserSession
    {
        // Các thông tin định danh
        public static int MaNguoiDung { get; set; }
        public static string TenDangNhap { get; set; }
        public static string HoTen { get; set; }
        public static string Email { get; set; }
        public static string VaiTro { get; set; }
        public static string SDT { get; set; }

        // Hàm này để xóa sạch dữ liệu khi Đăng xuất
        public static void Clear()
        {
            MaNguoiDung = 0;
            TenDangNhap = HoTen = Email = VaiTro = SDT = null;
        }

        // GIỎ HÀNG TẠM THỜI: Chứa danh sách các món đang chọn nhưng CHƯA nhấn "Gửi Order"
        public static List<CTDonHang> Cart { get; set; } = new List<CTDonHang>();

        // BÀN ĐANG CHỌN: Để biết các món trong Cart là dành cho bàn nào
        public static int CurrentTableId { get; set; } = 0;

        public static void ClearCart()
        {
            Cart.Clear();
            CurrentTableId = 0;
        }
    }
}
