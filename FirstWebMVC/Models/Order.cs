using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}