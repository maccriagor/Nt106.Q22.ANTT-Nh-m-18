using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;

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
        public string SDT { get; set; }

        [Column("diemtichluy")]
        public double DiemTichLuy { get; set; }

        [Column("ngaydangky")]
        public DateTime NgayDangKy { get; set; }
    }
}
