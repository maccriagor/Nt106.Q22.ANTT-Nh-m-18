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
    [Table("donhang")]
    public class DonHang : BaseModel
    {
        [PrimaryKey("madonhang", false)]
        public int MaDonHang { get; set; }

        [Column("mabanan")]
        public int MaBanAn { get; set; }

        [Column("manvorder")]
        public int MaNVOrder { get; set; }

        [Column("ngayorder")]
        public DateTime NgayOrder { get; set; }

        [Column("trangthai")]
        public string TrangThai { get; set; }

        [Column("tenkh")]
        public string TenKH { get; set; }

        [Column("sdtkh")]
        public string SDTKH { get; set; }

        [Column("ghichu")]
        public string GhiChu { get; set; }

        [Column("loaidonhang")]
        public string LoaiDonHang { get; set; }
    }
}
