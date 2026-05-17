using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    [Table("donhang")]
    public class DonHang : BaseModel
    {
        [PrimaryKey("madonhang", false)]
        public int MaDonHang { get; set; }

        [Column("mabanan")]
        public int MaBanAn { get; set; }

        // Người order (tham chiếu tới UserAccount.MaNguoiDung)
        [Column("manvorder")]
        public int MaNVOrder { get; set; }

        // Mặc định: CURRENT_TIMESTAMP
        [Column("ngayorder")]
        public DateTime NgayOrder { get; set; } = DateTime.Now;

        // 0: Chờ xác nhận, 1: Đang chế biến, 2: Hoàn thành, 3: Đã hủy
        [Column("trangthai")]
        public int TrangThai { get; set; }

        // Khách hàng không có tài khoản (khách vãng lai)
        [Column("tenkh")]
        public string TenKH { get; set; }

        // Số điện thoại khách (VARCHAR(15))
        [Column("sdtkh")]
        public string SDTKH { get; set; }

        [Column("ghichu")]
        public string GhiChu { get; set; }

        // Ví dụ: "Tại chỗ", "Mang về", "Giao hàng"
        [Column("loaidonhang")]
        public string LoaiDonHang { get; set; } = "Tại chỗ";

        
    }
}
