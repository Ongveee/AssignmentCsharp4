using AssignmentCsharp4_hieuptph18134.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AssignmentCsharp4_hieuptph18134.Controllers
{
    public class Product : Controller
    {
        private readonly AsmContext _context;

        public Product(AsmContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            try
            {
               // var pageNumber = page == null || page <=0 ? 1 :page.Value;
            //var pageSize = 10;
            var lstProduct = _context.SanPhams.AsNoTracking().OrderByDescending(x => x.DonGia);
            //PageList<SanPham> models = new PageList<SanPham>(lstProduct, pageNumber, pageSize);
            //ViewBag.CurrentPage = pageNumber;
            return View(lstProduct);

            }
            catch 
            {

                return RedirectToAction("Index","Home");
            }
            
        }
        //[Route("/{TenSanPham}", Name = "ListProduct")]
        public IActionResult List(int MaDanhMuc , int page=1)
        {
            
            var pageSize = 10;
            var danhmuc = _context.DanhMucs.Find(MaDanhMuc);
            var lstProduct = _context.SanPhams.AsNoTracking().OrderByDescending(x => x.DonGia);
            //PageList<SanPham> models = new PageList<SanPham>(lstProduct, page, pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.CurrentPage = danhmuc;
            return View(lstProduct);
           
        }
        [Route("/{TenSanPham}-{id}.html", Name ="ProductDetails")]
        public IActionResult Details(string id)
        {
            var product = _context.SanPhams.FirstOrDefault(x=>x.MaSanPham==id);
            if (product == null)
            {
                return RedirectToAction("Index");

            }
            return View(product);
        }
    }
}
