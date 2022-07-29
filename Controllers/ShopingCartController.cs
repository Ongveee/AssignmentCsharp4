using AssignmentCsharp4_hieuptph18134.Models;
using AssignmentCsharp4_hieuptph18134.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using AssignmentCsharp4_hieuptph18134;
using System.Threading.Tasks;
using AssignmentCsharp4_hieuptph18134.Extension;

namespace AssignmentCsharp4_hieuptph18134.Controllers
{
    public class ShopingCartController : Controller
    {
        private readonly AsmContext _context;
        private HoaDonsController _hdBansController;
        private HoaDonChiTietsController _chitietHdbansController;
        private SanPhamsController _hangsController;
        private SanPham _sanPham;
        private HoaDonChiTiet _chitietHdban;
        private List<HoaDonChiTiet> _lsthdct;
        private HoaDon _hoadonBan;
        private string makh = "ph12345678";

        public ShopingCartController(AsmContext context)
        {
            _context = context;
            _hdBansController = new HoaDonsController(context);
            _chitietHdbansController = new HoaDonChiTietsController(context);
            _hangsController = new SanPhamsController(context);
            _lsthdct = new List<HoaDonChiTiet>();
        }
        public async Task<IActionResult> Giohang()
        {
            string mhd;
            
                mhd = _context.HoaDons.FirstOrDefault(c => c.MaKhachHang == "ph12345678").MaHoaDon;
            
            return View(_context.HoaDonChiTiets.Where(c => c.MaHoaDon == mhd));
        }
        public async void themHD()
        {
            _hoadonBan = new HoaDon();
            _hoadonBan.MaHoaDon = "HD11111111";
            _hoadonBan.NgayBan = DateTime.Now;
            _hoadonBan.MaKhachHang = makh;
            
            _hdBansController.AddHoaDon(_hoadonBan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Addgiohang(string id, string query)
        {
            
            _chitietHdban = new HoaDonChiTiet();
            if (_context.HoaDons.Where(c => c.MaKhachHang == makh /*&& c.Trangthai == true*/).ToList().Count == 0)
            {
                themHD();
            }

            string makhadung = _context.HoaDons.FirstOrDefault(c => c.MaKhachHang == makh /*&& c.Trangthai == true*/)
                .MaHoaDon;
            if (_context.HoaDonChiTiets.Where(c => c.MaHoaDon == makhadung && c.MaSanPham == id).ToList().Count == 0)
            {
                var sp = _context.SanPhams.FirstOrDefault(c => c.MaSanPham == id);
                _chitietHdban.MaHoaDonCt = "HDCT"+Convert.ToString(_context.HoaDonChiTiets.Count()+1);
                _chitietHdban.MaHoaDon = makhadung;
                _chitietHdban.MaSanPham = id;
                _chitietHdban.SoLuong = Convert.ToInt32(1);
                _chitietHdban.Gia = _context.SanPhams.Find(id).DonGia;
                _chitietHdban.Color = "";
                _chitietHdban.Size = "";
                _chitietHdban.TenSanPham = sp.TenSanPham;
                _chitietHdban.Anh = sp.Anh;
                _chitietHdban.TongTien = _chitietHdban.SoLuong * _chitietHdban.Gia;
                //_lsthdct =  List<HoaDonChiTiet>.Count();
                _chitietHdbansController.AddChitietHDBan(_chitietHdban);
            }
            else
            {
                _chitietHdban = _context.HoaDonChiTiets.FirstOrDefault(c => c.MaHoaDon == makhadung && c.MaSanPham == id);
                _chitietHdban.SoLuong += Convert.ToInt32(query);
                _chitietHdbansController.EditChitietHDBan(_chitietHdban.MaHoaDonCt, _chitietHdban);
            }
            //SuaTongtien(makhadung);
        }

        ////thêm mới sp vào giỏ hàng
        //[HttpPost]

        //public IActionResult AddToCart(string productID, int? amount)

        //{
        //    List<CartItem> gioHang = GioHang;

        //    try
        //    {
        //        CartItem item = GioHang.SingleOrDefault(x => x.sanpham.MaSanPham == productID);
        //        if (item == null)
        //        {
        //            ViewData["Error"] = "ahahahhaha";
        //        }
        //        if (item != null)//đã có upadte số lượng
        //        {

        //                item.soluong = item.soluong + amount.Value;

        //            HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);

        //        }
        //        else//tạo mới để new sản phẩm mới
        //        {
        //            SanPham hh = _context.SanPhams.SingleOrDefault(x => x.MaSanPham == productID);
        //            item = new CartItem
        //            {
        //                soluong = amount.HasValue ? amount.Value : 1,
        //                sanpham = hh,
        //            };
        //            gioHang.Add(item);//thêm vào giỏ hàng
        //        }



        //        //lưu lại session
        //        HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
        //        return Json(new { success = true });
        //    }
        //    catch(Exception ex)
        //    {

        //        return Json(new { success = false });
        //    }


        //}


        ////xóa sp khỏi giỏ hàng
        //[HttpPost]
        //[Route("api/cart/remove")]
        //public ActionResult Remove(string productID)
        //{
        //    try
        //    {
        //        List<CartItem> gioHang = GioHang;
        //        CartItem item = GioHang.SingleOrDefault(x => x.sanpham.MaSanPham == productID);
        //        if (item != null)
        //        {
        //            gioHang.Remove(item);
        //        }
        //        //lưu lại session
        //        HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
        //        return Json(new { success = true });
        //    }
        //    catch(Exception e)
        //    {
        //        return Json(new { success = false });
        //    }
        //}
        //[HttpPost]
        //[Route("api/cart/update")]
        //public ActionResult UpdateCart(string productID, int? amount)
        //{
        //    //lấy giỏ hàng ra để xử lý
        //    var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");

        //    try
        //    {
        //        if (cart != null)
        //        {
        //            CartItem item = GioHang.SingleOrDefault(x => x.sanpham.MaSanPham == productID);
        //            if (item != null && amount.HasValue)//đã có cập nhập số lượng
        //            {
        //                item.soluong = amount.Value;
        //            }
        //            //lưu lại session
        //            HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
        //        }
        //        return Json(new { success = true });
        //    }
        //    catch(Exception e)
        //    {
        //        return Json(new { success = false });
        //    }
        //}

        [Route("cart.html", Name = "Cart")]
        public IActionResult Index()
        {
            
            var lstDonHang = _context.HoaDonChiTiets.Where(x => x.MaHoaDon == (_context.HoaDons.FirstOrDefault(x => x.MaKhachHang == "ph12345678").MaHoaDon)).ToList();

            return View(lstDonHang);
        }

    }
}
