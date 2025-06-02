namespace API.Entities;
using API.Types;

public class Vendor // informations about single vendor
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public VendorCategory Category { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public List<Photo> Photos { get; set; } = [];
    public ICollection<WeddingVendor> AssignedToWeddings { get; set; } = new List<WeddingVendor>();

}
