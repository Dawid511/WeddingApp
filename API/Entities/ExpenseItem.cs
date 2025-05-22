namespace API.Entities;


public class ExpenseItem
{
    public int Id { get; set; }
    public int ExpenseListId { get; set; }
    public ExpenseList ExpenseList { get; set; } = null!;

    public required string Name { get; set; }  // np. "Fotograf", "Sala"
    public decimal EstimatedCost { get; set; }
    public decimal? ActualCost { get; set; }
    public bool IsPaid { get; set; } = false;
    public string? Notes { get; set; }
}
