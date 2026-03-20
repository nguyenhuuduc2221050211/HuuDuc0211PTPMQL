using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [StringLength(10, ErrorMessage = "Mã sinh viên tối đa 10 ký tự")]
        public string Studentcode {get; set;}
        
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(50, ErrorMessage = "Họ tên tối đa 50 ký tự")]
        public string Fullname {get; set;}
    }
}