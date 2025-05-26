namespace API.DTOs;

public class GuestListDto
{
    public int Id { get; set; }
    public int WeddingId { get; set; }
    public List<GuestDto> Guests { get; set; } = [];
}
