namespace API.DTOs;

public class UpdateExpenseItemDto
{
    public string? Name { get; set; }
    public decimal? EstimatedCost { get; set; }
    public decimal? ActualCost { get; set; }
    public bool? IsPaid { get; set; }
    public string? Notes { get; set; }
}
