using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using System.Linq;

namespace FirstWebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);

            if(customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Orders(int id)
        {
            var orders = _context.Orders
                .Where(o => o.CustomerID == id)
                .ToList();

            return View(orders);
        }
    }
}