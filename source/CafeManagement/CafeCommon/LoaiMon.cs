using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CafeCommon
{
    [Table("loaimon")] 
    public class LoaiMon : BaseModel
    {
        [PrimaryKey("maloaimon", false)]
        public int MaLoaiMon { get; set; }

        [Column("tenloai")] 
        public string TenLoai { get; set; }

        [Column("mota")] 
        public string MoTa { get; set; }

        [Column("trangthai")] 
        public bool TrangThai { get; set; }
    }
}
