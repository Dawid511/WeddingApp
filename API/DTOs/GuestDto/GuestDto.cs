namespace API.DTOs;

public class GuestDto
{
    public int Id { get; set; }
    public int GuestListId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int Count { get; set; }
    public string Status { get; set; } = "Invited";
    public string? Notes { get; set; }
}
