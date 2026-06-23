using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    [Table("tinnhan")]
public class TinNhan : BaseModel
    {
        [PrimaryKey("matinnhan", false)]
        public int MaTinNhan { get; set; }

        [Column("manguoigui")]
        public int SenderId { get; set; }

        [Column("manguoinhan")]
        public int? RecipientId { get; set; } // Nếu là gửi mọi người, bạn có thể quy ước giá trị này là 0 hoặc -1

        [Column("noidung")]
        public string Content { get; set; }

        [Column("thoigian")]
        public DateTime Timestamp { get; set; }

        [Column("dadoc")]
        public bool IsRead { get; set; }
    }
}
