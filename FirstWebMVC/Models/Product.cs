using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Range(0,100000)]
        public double Price { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}