namespace API.DTOs;

public class VendorDto
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public string Category { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}
