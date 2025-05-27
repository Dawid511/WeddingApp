using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateGuestDto
{
    [Required]
    public int GuestListId { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Notes { get; set; }
}
