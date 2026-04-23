using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CafeCommon
{
    [Table("useraccount")] // <--- This must match the Supabase table name exactly
    public class Employee : BaseModel
    {
        [PrimaryKey("manguoidung", false)] // The FK in hoadon points to this
        public int MaNV { get; set; }

        // Even if you don't use it now, having the username helps for debugging
        [Column("username")]
        public string UserName { get; set; }
    }

    [Table("banan")]
    public class Table : BaseModel
    {
        [PrimaryKey("mabanan", false)]
        public int MaBanAn { get; set; }
    }

    [Table("donhang")] // Ensure this matches your Supabase table name
    public class Order : BaseModel
    {
        [PrimaryKey("madonhang", false)] // Matching the lowercase standard
        public int MaDonhang { get; set; }
    }

    [Table("khachhang")]
    public class KhachHang : BaseModel
    {
        [PrimaryKey("makh", false)]
        public int MaKH { get; set; }
    }

    [Table("khuyenmai")]
    public class KhuyenMai : BaseModel
    {
        [PrimaryKey("makm", false)]
        public int MaKM { get; set; }

        [Column("loaikm")]
        public string loaiKM { get; set; }

        [Column("sotiengiam")]
        public decimal sotiengiam { get; set; }
    }
}
