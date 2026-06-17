using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{
    public class ExportDetail
    {
        public int ExportDetailID { get; set; }


        public int ExportReceiptID { get; set; }

        [ForeignKey("ExportReceiptID")]
        public ExportReceipt? ExportReceipt { get; set; }


        public int DeviceID { get; set; }

        [ForeignKey("DeviceID")]
        public Device? Device { get; set; }


        public int Quantity { get; set; }


        public decimal ExportPrice { get; set; }


        public decimal TotalMoney
        {
            get
            {
                return Quantity * ExportPrice;
            }
        }
    }
}