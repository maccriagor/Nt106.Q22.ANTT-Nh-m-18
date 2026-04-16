using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    [Table ("useraccount")]
    public class UserAccount : BaseModel
    {
        [PrimaryKey("manguoidung", false)] // false vì dùng SERIAL tự tăng
        public int MaNguoiDung { get; set; }

        [Column("tendangnhap")]
        public string TenDangNhap { get; set; }

        [Column("sdt")]
        public string SDT { get; set; }

        [Column("matkhau")]
        public string MatKhau { get; set; }

        [Column("vaitro")]
        public string VaiTro { get; set; }

        [Column("hoten")]
        public string HoTen { get; set; }

        [Column("trangthaionline")]
        public bool TrangThaiOnline { get; set; }

        [Column("token")]
        public string Token { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
