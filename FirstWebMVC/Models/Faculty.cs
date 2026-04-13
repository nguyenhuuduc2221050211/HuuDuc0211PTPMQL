using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }

        public string FacultyName { get; set; }
    }
}