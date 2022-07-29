using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentCsharp4_hieuptph18134.Models;

namespace AssignmentCsharp4_hieuptph18134.Controllers
{
    public class HoaDonChiTietsController : Controller
    {
        private readonly AsmContext _context;

        public HoaDonChiTietsController(AsmContext context)
        {
            _context = context;
        }

        // GET: HoaDonChiTiets
        public async Task<IActionResult> Index()
        {
            var assignmentCsharp4Context = _context.HoaDonChiTiets.Include(h => h.MaHoaDonNavigation).Include(h => h.MaSanPhamNavigation);
            return View(await assignmentCsharp4Context.ToListAsync());
        }

        // GET: HoaDonChiTiets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonChiTiet = await _context.HoaDonChiTiets
                .Include(h => h.MaHoaDonNavigation)
                .Include(h => h.MaSanPhamNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDonCt == id);
            if (hoaDonChiTiet == null)
            {
                return NotFound();
            }

            return View(hoaDonChiTiet);
        }

        // GET: HoaDonChiTiets/Create
        public IActionResult Create()
        {
            ViewData["MaHoaDon"] = new SelectList(_context.HoaDons, "MaHoaDon", "MaHoaDon");
            ViewData["MaSanPham"] = new SelectList(_context.SanPhams, "MaSanPham", "MaSanPham");
            return View();
        }

        // POST: HoaDonChiTiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHoaDonCt,MaHoaDon,SoLuong,Gia,Size,Color,TongTien,MaSanPham")] HoaDonChiTiet hoaDonChiTiet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonChiTiet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHoaDon"] = new SelectList(_context.HoaDons, "MaHoaDon", "MaHoaDon", hoaDonChiTiet.MaHoaDon);
            ViewData["MaSanPham"] = new SelectList(_context.SanPhams, "MaSanPham", "MaSanPham", hoaDonChiTiet.MaSanPham);
            return View(hoaDonChiTiet);
        }

        // GET: HoaDonChiTiets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonChiTiet = await _context.HoaDonChiTiets.FindAsync(id);
            if (hoaDonChiTiet == null)
            {
                return NotFound();
            }
            ViewData["MaHoaDon"] = new SelectList(_context.HoaDons, "MaHoaDon", "MaHoaDon", hoaDonChiTiet.MaHoaDon);
            ViewData["MaSanPham"] = new SelectList(_context.SanPhams, "MaSanPham", "MaSanPham", hoaDonChiTiet.MaSanPham);
            return View(hoaDonChiTiet);
        }

        // POST: HoaDonChiTiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHoaDonCt,MaHoaDon,SoLuong,Gia,Size,Color,TongTien,MaSanPham")] HoaDonChiTiet hoaDonChiTiet)
        {
            if (id != hoaDonChiTiet.MaHoaDonCt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonChiTiet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonChiTietExists(hoaDonChiTiet.MaHoaDonCt))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHoaDon"] = new SelectList(_context.HoaDons, "MaHoaDon", "MaHoaDon", hoaDonChiTiet.MaHoaDon);
            ViewData["MaSanPham"] = new SelectList(_context.SanPhams, "MaSanPham", "MaSanPham", hoaDonChiTiet.MaSanPham);
            return View(hoaDonChiTiet);
        }

        // GET: HoaDonChiTiets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonChiTiet = await _context.HoaDonChiTiets
                .Include(h => h.MaHoaDonNavigation)
                .Include(h => h.MaSanPhamNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDonCt == id);
            if (hoaDonChiTiet == null)
            {
                return NotFound();
            }

            return View(hoaDonChiTiet);
        }

        // POST: HoaDonChiTiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hoaDonChiTiet = await _context.HoaDonChiTiets.FindAsync(id);
            _context.HoaDonChiTiets.Remove(hoaDonChiTiet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonChiTietExists(string id)
        {
            return _context.HoaDonChiTiets.Any(e => e.MaHoaDonCt == id);
        }
        public void AddChitietHDBan(HoaDonChiTiet tblChitietHdban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblChitietHdban);
                _context.SaveChanges();
            }
        }

        public void EditChitietHDBan(string id, HoaDonChiTiet tblChitietHdban)
        {
            if (id != tblChitietHdban.MaHoaDonCt)
            {
                return;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblChitietHdban);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonChiTietExists(tblChitietHdban.MaHoaDonCt))
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}
