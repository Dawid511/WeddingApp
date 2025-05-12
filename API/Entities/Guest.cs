namespace API.Entities;
using API.Types;

public class Guest
{
    public int Id { get; set; }

    public int GuestListId { get; set; }
    public GuestList GuestList { get; set; } = null!;

    public required string FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public RSVPStatus RSVP { get; set; } = RSVPStatus.Pending;
    public string? Notes { get; set; }
}
