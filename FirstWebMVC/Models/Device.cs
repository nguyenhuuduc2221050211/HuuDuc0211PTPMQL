public class Device
{
    public int DeviceId { get; set; }
    public string DeviceName { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
}