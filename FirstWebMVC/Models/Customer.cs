using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage ="Tên không được để trống")]
        public string CustomerName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<Order> Orders { get; set; }
    }
}