using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    [Table("banan")]
    public class BanAn : BaseModel
    {
        [PrimaryKey("mabanan", false)]
        public int MaBanAn { get; set; }

        [Column("tenban")]
        public string TenBan { get; set; }

        [Column("sochongoi")]
        public int SoChoNgoi { get; set; }

        [Column("trangthai")]
        public string TrangThai { get; set; }

        [Column("manv")]
        public int MaNV { get; set; }

        [Column("ngaytao")]
        public DateTime NgayTao { get; set; }


    }
}
