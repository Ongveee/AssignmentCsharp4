using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentCsharp4_hieuptph18134.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public string MaHoaDon { get; set; }
        public string MaKhachHang { get; set; }
        public DateTime NgayBan { get; set; }

        public virtual KhachHang MaKhachHangNavigation { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
