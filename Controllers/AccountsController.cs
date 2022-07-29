using AspNetCoreHero.ToastNotification.Abstractions;
using AssignmentCsharp4_hieuptph18134.Models;
using AssignmentCsharp4_hieuptph18134.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCsharp4_hieuptph18134.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AsmContext _context;
        public INotyfService _notyfService { get; }

        public AccountsController(AsmContext context,INotyfService notyfService) 
        {
            _context = context;
            _notyfService = notyfService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("danh-nhap.html",Name ="DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel khach, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var khachHang = _context.KhachHangs.FirstOrDefault(x=>x.Email==khach.UserName);
                var pass = khach.Password;
                if (khachHang.MatKhau != pass)
                {
                    return View(khach);
                }
              //  if (khachHang.tr == false) return RedirectToAction("thông báo", "Khachhang");
                if (khachHang.MatKhau == pass)
                {
                    //string returnUrl = "sss";
                    //return RedirectResult(returnUrl);
                }
            }
            return View(khach);
        }
    }
}
