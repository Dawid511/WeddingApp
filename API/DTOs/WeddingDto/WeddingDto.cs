namespace API.DTOs;

public class WeddingDto
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime WeddingDate { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedAt { get; set; }
}
