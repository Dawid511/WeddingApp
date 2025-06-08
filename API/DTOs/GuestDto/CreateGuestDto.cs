public class CreateGuestDto
{
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int Count { get; set; } = 1;
    public string? Notes { get; set; }
}
