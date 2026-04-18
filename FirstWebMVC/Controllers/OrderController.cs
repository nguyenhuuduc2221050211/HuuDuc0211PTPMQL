using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using System.Linq;

namespace FirstWebMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if(ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }
    }
}