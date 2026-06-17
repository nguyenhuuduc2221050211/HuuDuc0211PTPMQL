using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class ExportReceipt
    {
        [Key]
        public int ExportReceiptID { get; set; }

        public DateTime ExportDate { get; set; }

        public string Receiver { get; set; } = "";

        public List<ExportDetail>? ExportDetails { get; set; }
        public decimal TotalAmount
{
    get
    {
        if (ExportDetails == null)
            return 0;

        return ExportDetails.Sum(x => x.Quantity * x.ExportPrice);
    }
}
    }
}