using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using FirstWebMVC.ViewModels;
using FirstWebMVC.Services;

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
            var data = from s in _context.Students
               join f in _context.Faculties
               on s.FacultyID equals f.FacultyID
               select new StudentFacultyVM
               {
                   StudentCode = s.StudentCode,
                   Fullname = s.Fullname,
                   FacultyName = f.FacultyName
               };

     return View(data.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

             return RedirectToAction("Index");
        }
        return View(student);
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
            var st = _context.Students.Find(student.StudentCode);

            if (st != null)
            {
                _context.Students.Remove(st);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ImportExcel()
        {
            return View();
        }
        [HttpPost]
public async Task<IActionResult> ImportExcel(IFormFile file)
{
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

    if (file == null || file.Length == 0)
        return Content("File không hợp lệ");

    using (var stream = new MemoryStream())
    {
        await file.CopyToAsync(stream);

        using (var package = new ExcelPackage(stream))
        {
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null || worksheet.Dimension == null)
                return Content("File Excel rỗng");

            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                var student = new Student
                {
                    StudentCode = worksheet.Cells[row, 1].Text,
                    Fullname = worksheet.Cells[row, 2].Text
                };

                if (!_context.Students.Any(s => s.StudentCode == student.StudentCode))
                {
                    _context.Students.Add(student);
                }
            }

            _context.SaveChanges();
        }
    }

    return RedirectToAction("Index");
}
    }
}