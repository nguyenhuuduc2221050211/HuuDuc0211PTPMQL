using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using System.Linq;

namespace FirstWebMVC.Controllers
{
    public class FacultyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacultyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách
        public IActionResult Index()
        {
            var faculties = _context.Faculties.ToList();
            return View(faculties);
        }

        // GET Create
        public IActionResult Create()
        {
            return View();
        }

        // POST Create
       [HttpPost]
public IActionResult Create(Faculty faculty)
{
    if (!ModelState.IsValid)
    {
        foreach (var value in ModelState.Values)
        {
            foreach (var error in value.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }

        return View(faculty);
    }

    _context.Faculties.Add(faculty);
    _context.SaveChanges();

    return RedirectToAction("Index");
}
        // POST Edit
        [HttpPost]
        public IActionResult Edit(Faculty faculty)
        {
            if(ModelState.IsValid)
            {
                _context.Faculties.Update(faculty);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faculty);
        }

        // GET Delete
        public IActionResult Delete(int id)
        {
            var faculty = _context.Faculties.Find(id);
            if(faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var faculty = _context.Faculties.Find(id);

            if(faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}