using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;
namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Student std)
        {
            ViewBag.ThongBao = "Xin chào: " + std.Fullname + " - Mã sinh viên: " + std.Studentcode;
            return View();
        }
    }
}