using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class ImportReceipt
    {
        [Key]
        public int ImportReceiptID { get; set; }

        public DateTime ImportDate { get; set; }

        public List<ImportDetail>? ImportDetails { get; set; }
        public decimal TotalAmount
{
    get
    {
        if (ImportDetails == null)
            return 0;

        return ImportDetails.Sum(x => x.Quantity * x.ImportPrice);
    }
}
    }
}