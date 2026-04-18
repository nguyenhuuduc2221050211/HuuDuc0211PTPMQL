using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public Order Order { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}