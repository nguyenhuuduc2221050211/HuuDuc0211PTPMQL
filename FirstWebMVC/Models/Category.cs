using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }


        [Required(ErrorMessage = "Tên loại thiết bị không được để trống")]
        public string CategoryName { get; set; }


        public List<Device>? Devices { get; set; }
    }
}