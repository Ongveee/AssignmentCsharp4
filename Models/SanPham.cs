using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentCsharp4_hieuptph18134.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MaDanhMuc { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public string Anh { get; set; }
        public string GhiChu { get; set; }

        public virtual DanhMuc MaDanhMucNavigation { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
