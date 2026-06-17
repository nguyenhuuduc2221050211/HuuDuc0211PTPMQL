using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }


        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
        public string SupplierName { get; set; }


        public string Address { get; set; }


        public string Phone { get; set; }


        public List<Device>? Devices { get; set; }
    }
}