using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentCsharp4_hieuptph18134.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
