using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentCsharp4_hieuptph18134.Models
{
    public partial class HoaDonChiTiet
    {
        public string MaHoaDonCt { get; set; }
        public string MaHoaDon { get; set; }
        public int SoLuong { get; set; }
        public double Gia { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public double TongTien { get; set; }
        public string MaSanPham { get; set; }
        public bool? Trangthai { get; set; }
        public string TenSanPham { get; set; }
        public string Anh { get; set; }

        public virtual HoaDon MaHoaDonNavigation { get; set; }
        public virtual SanPham MaSanPhamNavigation { get; set; }
    }
}
