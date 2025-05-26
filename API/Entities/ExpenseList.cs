namespace API.Entities;

public class ExpenseList
{
    public int Id { get; set; }

    public int WeddingId { get; set; }
    public Wedding Wedding { get; set; } = null!;

    public ICollection<ExpenseItem> Items { get; set; } = new List<ExpenseItem>();
}
