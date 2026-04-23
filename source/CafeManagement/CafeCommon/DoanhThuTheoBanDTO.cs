using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    public class RevenueByTableDTO
    {
        public string TenBan { get; set; }
        public int MaBanAn { get; set; }
        public int SoLuongHoaDon { get; set; }
        public decimal DoanhThu { get; set; }
        public decimal HoaDonLonNhat { get; set; }
        public decimal HoaDonNhoNhat { get; set; }
        public decimal DoanhThuTB { get; set; }
    }
}
