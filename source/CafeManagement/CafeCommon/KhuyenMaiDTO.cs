using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    public class KhuyenMaiDTO
    {
        public int MaKM { get; set; }
        public string CodeKM { get; set; }
        public string MoTa { get; set; }
        public string LoaiKM { get; set; }
        public decimal GiaTriGiam { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayHetHan { get; set; }
        public bool TrangThai { get; set; }
    }
}
