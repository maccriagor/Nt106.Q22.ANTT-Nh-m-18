using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    [Table ("UserAccount")]
    public class UserAccount : BaseModel
    {
        [PrimaryKey("MaNguoiDung", false)] // false vì dùng SERIAL tự tăng
        public int MaNguoiDung { get; set; }

        [Column("TenDangNhap")]
        public string TenDangNhap { get; set; }

        [Column("MatKhau")]
        public string MatKhau { get; set; }

        [Column("VaiTro")]
        public string VaiTro { get; set; }

        [Column("HoTen")]
        public string HoTen { get; set; }

        [Column("TrangThaiOnline")]
        public bool TrangThaiOnline { get; set; }

        [Column("Token")]
        public string Token { get; set; }

        [Column("Email")]
        public string Email { get; set; }
    }
}
