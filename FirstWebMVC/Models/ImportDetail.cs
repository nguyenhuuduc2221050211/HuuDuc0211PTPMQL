public class ImportDetail
{
    public int ImportDetailId { get; set; }

    public int ImportId { get; set; }
    public Import Import { get; set; }

    public int DeviceId { get; set; }
    public Device Device { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }
}