using OfficeOpenXml;
using FirstWebMVC.Models;

namespace FirstWebMVC.Services
{
    public class ExcelService
    {
        public List<Student> ReadStudentFromExcel(Stream stream)
        {
            var students = new List<Student>();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var student = new Student
                    {
                        StudentCode = worksheet.Cells[row, 1].Text,
                        Fullname = worksheet.Cells[row, 2].Text
                    };

                    students.Add(student);
                }
            }

            return students;
        }
    }
}