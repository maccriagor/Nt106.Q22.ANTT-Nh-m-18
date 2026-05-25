using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CafeCommon
{
    [Table("khachhang")] 
    public class KhachHang : BaseModel
    {
        [PrimaryKey("makh", false)]
        public int MaKH { get; set; }

        [Column("tenkh")]
        public string TenKH { get; set; }

        [Column("sdt")]
        public string SoDienThoai { get; set; }

        [Column("diemtichluy")]
        public float DiemTichLuy { get; set; }
        [Column("ngaydangky")]
        public DateTime NgayDangKy { get; set; }
    }
}