using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{
    public class ImportDetail
    {
        public int ImportDetailID { get; set; }


        // Khóa ngoại phiếu nhập
        public int ImportReceiptID { get; set; }

        [ForeignKey("ImportReceiptID")]
        public ImportReceipt? ImportReceipt { get; set; }


        // Khóa ngoại thiết bị
        public int DeviceID { get; set; }

        [ForeignKey("DeviceID")]
        public Device? Device { get; set; }


        public int Quantity { get; set; }


        public decimal ImportPrice { get; set; }


        public decimal TotalMoney
        {
            get
            {
                return Quantity * ImportPrice;
            }
        }
    }
}