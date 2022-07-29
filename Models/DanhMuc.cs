using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentCsharp4_hieuptph18134.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
