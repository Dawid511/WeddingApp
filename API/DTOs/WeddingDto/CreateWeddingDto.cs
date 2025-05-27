namespace API.DTOs;

public class CreateWeddingDto
{
    public int AppUserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime WeddingDate { get; set; }
    public string? Location { get; set; }
}
