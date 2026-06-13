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
        ViewBag.Faculties = _context.Faculties.ToList();

        return View();
    }
       
    [HttpPost]
public IActionResult Create(Student student)
{
    Console.WriteLine("StudentCode: " + student.StudentCode);
    Console.WriteLine("Fullname: " + student.Fullname);
    Console.WriteLine("FacultyID: " + student.FacultyID);

    if (!ModelState.IsValid)
    {
        foreach (var item in ModelState.Values)
        {
            foreach (var error in item.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }

        ViewBag.Faculties = _context.Faculties.ToList();
        return View(student);
    }

    _context.Students.Add(student);
    _context.SaveChanges();

    Console.WriteLine("Lưu thành công");

    return RedirectToAction("Index");
}
       
        public IActionResult Edit(string id)
{
    var student = _context.Students.Find(id);

    if (student == null)
    {
        return NotFound();
    }

    ViewBag.Faculties = _context.Faculties.ToList();

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

    ViewBag.Faculties = _context.Faculties.ToList();

    return View(student);
}

public IActionResult Delete(string id)
{
    var student = _context.Students.Find(id);

    if (student == null)
    {
        return NotFound();
    }

    return View(student);
}
[HttpPost, ActionName("Delete")]
public IActionResult DeleteConfirmed(string id)
{
    var student = _context.Students.Find(id);

    if (student != null)
    {
        _context.Students.Remove(student);
        _context.SaveChanges();
    }

    return RedirectToAction("Index");
}
        public IActionResult ImportExcel()
        {
            return View();
        }
        

    [HttpPost]
public IActionResult ImportExcel(IFormFile file)
{
    if (file == null || file.Length == 0)
    {
        ViewBag.Message = "Vui lòng chọn file Excel";
        return View();
    }

    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

    using (var stream = new MemoryStream())
    {
        file.CopyTo(stream);

        using (var package = new ExcelPackage(stream))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                string code = worksheet.Cells[row, 1].Text;
                string name = worksheet.Cells[row, 2].Text;
                int facultyId = int.Parse(worksheet.Cells[row, 3].Text);


                // Kiểm tra mã sinh viên đã tồn tại chưa
                bool exists = _context.Students
                    .Any(s => s.StudentCode == code);

                if (!exists)
                {
                    Student student = new Student()
                    {
                        StudentCode = code,
                        Fullname = name,
                        FacultyID = facultyId
                    };

                    _context.Students.Add(student);
                }
            }

            _context.SaveChanges();
        }
    }

    // Sau khi import quay về danh sách sinh viên
    return RedirectToAction("Index");
} 
    }
}