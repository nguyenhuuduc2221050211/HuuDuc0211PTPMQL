using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{
    public class Device
    {
        [Key]
        public int DeviceID { get; set; }


        [Required]
        public string DeviceName { get; set; }


        public decimal Price { get; set; }


        public int Quantity { get; set; }


        public string Description { get; set; }


        // Khóa ngoại Category
        public int CategoryID { get; set; }


        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }


        // Khóa ngoại Supplier
        public int SupplierID { get; set; }


        [ForeignKey("SupplierID")]
        public Supplier? Supplier { get; set; }
    }
}