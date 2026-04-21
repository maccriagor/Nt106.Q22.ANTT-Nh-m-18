using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CafeCommon
{
    [Table("khuyenmai")]
    public class KhuyenMai : BaseModel
    {
        [PrimaryKey("makm", false)]
        public int MaKM { get; set; }

        [Column("codekm")]
        public string CodeKM { get; set; }

        [Column("mota")]
        public string MoTa { get; set; }

        [Column("loaikm")]
        public string LoaiKM { get; set; } // 'Phần trăm' hoặc 'Số tiền'

        [Column("giatrigiam")]
        public decimal GiaTriGiam { get; set; }

        [Column("ngaybatdau")]
        public DateTime NgayBatDau { get; set; }

        [Column("ngayhethan")]
        public DateTime NgayHetHan { get; set; }

        [Column("trangthai")]
        public bool TrangThai { get; set; } = true;
    }
}