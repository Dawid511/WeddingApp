namespace API.Entities;

public class GuestList  // Whole guest list for weeding
{
    public int Id { get; set; }

    public int WeddingId { get; set; }
    public Wedding Wedding { get; set; } = null!;

    public ICollection<Guest> Guests { get; set; } = new List<Guest>();
}
