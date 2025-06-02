namespace API.DTOs;

public class UpdateGuestDto
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? Count { get; set; }
    public string? Notes { get; set; }
    public string? Status { get; set; } // "Invited", "Accepted", "Declined"
}
