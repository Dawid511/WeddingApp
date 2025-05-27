namespace API.DTOs;

public class CreateExpenseItemDto
{
    public int ExpenseListId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal EstimatedCost { get; set; }
    public decimal? ActualCost { get; set; }
    public bool IsPaid { get; set; } = false;
    public string? Notes { get; set; }
}
