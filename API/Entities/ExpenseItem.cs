namespace API.Entities;


public class ExpenseItem    // single expense
{
    public int Id { get; set; }
    public int ExpenseListId { get; set; }  // relation with list 1 to many
    public ExpenseList ExpenseList { get; set; } = null!;

    public required string Name { get; set; }  // np. "Fotograf", "Sala"
    public decimal EstimatedCost { get; set; }
    public decimal? ActualCost { get; set; }
    public bool IsPaid { get; set; } = false;
    public string? Notes { get; set; }
}
