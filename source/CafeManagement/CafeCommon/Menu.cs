using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    [Table("menu")]
    public class Menu : BaseModel
    {
        [PrimaryKey("mamon", false)]
        public int MaMon { get; set; }

        [Column("tenmon")]
        public string TenMon { get; set; }

        [Column("gia")]
        public decimal Gia { get; set; }

        [Column("mota")]
        public string MoTa { get; set; }

        [Column("trangthai")]
        public string TrangThai { get; set; } // "Còn hàng" hoặc "Hết hàng"

        [Column("maloaimon")]
        public int MaLoaiMon { get; set; }
    }
}
