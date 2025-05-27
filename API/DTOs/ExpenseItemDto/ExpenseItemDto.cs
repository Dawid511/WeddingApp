namespace API.DTOs;

public class ExpenseItemDto
{
    public int Id { get; set; }
    public int ExpenseListId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal EstimatedCost { get; set; }
    public decimal? ActualCost { get; set; }
    public bool IsPaid { get; set; }
    public string? Notes { get; set; }
}
