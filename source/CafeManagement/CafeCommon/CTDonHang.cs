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
    [Table("ctdonhang")]
    public class CTDonHang : BaseModel
    {
        [PrimaryKey("mact", false)]
        public int MaCT { get; set; }

        [Column("madonhang")]
        public int MaDonHang { get; set; }

        [Column("mamon")]
        public int MaMon { get; set; }

        [Column("soluong")]
        public int SoLuong { get; set; }

        [Column("dongia")]
        public double DonGia { get; set; }

        [Column("ghichukhach")]
        public string GhiChuKhach { get; set; }

        [Column("ghichubep")]
        public string GhiChuBep { get; set; }

        [Column("manhanvienchebien")]
        public int MaNhanVienCheBien { get; set; }

        [Column("uutien")]
        public bool UuTien { get; set; }

        [Column("thoigianbatdau")]
        public DateTime? ThoigianBatDau { get; set; }

        [Column("thoigianhoanthanh")]
        public DateTime? ThoigianHoanThanh { get; set; }

        [Column("thoigiandukien")]
        public int ThoiGianDuKien { get; set; }

        [Column("trangthaiitem")]
        public string TrangThaiItem { get; set; }
    }
}