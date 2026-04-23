using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace CafeCommon
{
    [Table("hoadon")] 
    public class Bill : BaseModel
    {
        [PrimaryKey("mahd", false)] 
        public int MaHD { get; set; }

        [Column("madonhang")]
        public int MaDonhang { get; set; }

        [Column("mabanan")]
        public int MaBanAn { get; set; }

        [Column("manv")]
        public int MaNV { get; set; }

        [Column("makh")]
        public int? MaKH { get; set; }

        [Column("makm")]
        public int? MaKM { get; set; }

        [Column("ngaytao")]
        public DateTime NgayTao { get; set; }

        [Column("tongtien")]
        public decimal TongTien { get; set; }

        [Column("sotiengiam")]
        public decimal SoTienGiam { get; set; }

        [Column("thanhtien")]
        public decimal ThanhTien { get; set; }

        [Column("trangthai")]
        public string TrangThai { get; set; }

        [Column("phuongthucthanhtoan")]
        public string PhuongThucThanhToan { get; set; }
    }
}