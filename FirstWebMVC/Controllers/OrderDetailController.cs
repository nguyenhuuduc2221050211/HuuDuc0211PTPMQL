using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using System.Linq;

namespace FirstWebMVC.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var details = _context.OrderDetails.ToList();
            return View(details);
        }

        public IActionResult Create()
        {
            ViewBag.Orders = _context.Orders.ToList();
            ViewBag.Products = _context.Products.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderDetail detail)
        {
            if(ModelState.IsValid)
            {
                _context.OrderDetails.Add(detail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detail);
        }
    }
}