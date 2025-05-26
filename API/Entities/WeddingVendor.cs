namespace API.Entities;

public class WeddingVendor
{
    public int WeddingId { get; set; }
    public Wedding Wedding { get; set; } = null!;

    public int VendorId { get; set; }
    public Vendor Vendor { get; set; } = null!;
}