namespace API.DTOs;

public class ExpenseListDto
{
    public int Id { get; set; }
    public int WeddingId { get; set; }
    public List<ExpenseItemDto> Items { get; set; } = [];
}
