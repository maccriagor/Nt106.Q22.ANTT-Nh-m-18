using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCommon
{
    [Table("ctdonhang")] // Đảm bảo tên bảng trong DB là ctdonhang
    public class CTDonHang : BaseModel
    {
        [PrimaryKey("mact", false)]
        public int MaCT { get; set; }

        [Column("madonhang")]
        public int? MaDonHang { get; set; }

        [Column("mamon")]
        public int MaMon { get; set; }

        [Column("soluong")]
        public int SoLuong { get; set; }

        [Column("dongia")]
        public decimal DonGia { get; set; }

        [Column("ghichukhach")]
        public string? GhiChuKhach { get; set; }

        [Column("ghichubep")]
        public string? GhiChuBep { get; set; }

        [Column("manhanvienchebien")]
        public int? MaNhanVienCheBien { get; set; }

        [Column("uutien")]
        public bool UuTien { get; set; } = false;

        [Column("thoigianbatdau")]
        public DateTime? ThoiGianBatDau { get; set; }

        [Column("thoigianhoanthanh")]
        public DateTime? ThoiGianHoanThanh { get; set; }

        [Column("thoigiandukien")]
        public int? ThoiGianDuKien { get; set; }

        [Column("trangthaiitem")]
        public int TrangThaiItem { get; set; } = 0; // 0: Chờ, 1: Đang làm, 2: Xong
    }
}
