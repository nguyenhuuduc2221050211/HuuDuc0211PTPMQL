using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Student
    {
        [Key]
        public string Studentcode {get; set;}
        public string Fullname {get; set;}
    }
}