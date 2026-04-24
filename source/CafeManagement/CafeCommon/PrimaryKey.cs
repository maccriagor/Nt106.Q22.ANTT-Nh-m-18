using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    [Table("useraccount")]
    public class nhanvien : BaseModel
    {
        [PrimaryKey("manguoidung", false)] 
        [Column("manguoidung")]           
        public int manv { get; set; }
    }

    [Table("banan")]
    public class banan : BaseModel { [PrimaryKey("mabanan")] public int mabanan { get; set; } }
}
