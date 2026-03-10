using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

             return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }
        public IActionResult Delete(string id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            var st = _context.Students.Find(student.Studentcode);

            if (st != null)
            {
                _context.Students.Remove(st);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}