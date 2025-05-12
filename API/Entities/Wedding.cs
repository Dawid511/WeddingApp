namespace API.Entities;
using API.Types;

public class Wedding
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public DateTime WeddingDate { get; set; }
    public string? Location { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public GuestList GuestList { get; set; } = null!;
    public ExpenseList ExpenseList { get; set; } = null!;

    public ICollection<WeddingVendor> SelectedVendors { get; set; } = new List<WeddingVendor>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
