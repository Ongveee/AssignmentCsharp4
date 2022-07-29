using AssignmentCsharp4_hieuptph18134.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AssignmentCsharp4_hieuptph18134.ModelView
{
    public class CartItem
    {
        public SanPham sanpham { get; set; }
        public int soluong { get; set; }
        public double tongtien => soluong * sanpham.DonGia;
    }
}
