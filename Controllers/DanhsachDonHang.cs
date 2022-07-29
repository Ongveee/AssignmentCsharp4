using AssignmentCsharp4_hieuptph18134.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AssignmentCsharp4_hieuptph18134.Controllers
{
    public class DanhsachDonHang : Controller
    {
        private readonly AsmContext _context;

        public DanhsachDonHang(AsmContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var lstDonHang = _context.HoaDonChiTiets.Where(x => x.MaHoaDon == (_context.HoaDons.FirstOrDefault(x => x.MaKhachHang == "ph12345678").MaHoaDon)).ToList();
            return View(lstDonHang);
        }
    }
}
