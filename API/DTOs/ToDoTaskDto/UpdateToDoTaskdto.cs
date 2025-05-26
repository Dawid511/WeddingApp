namespace API.DTOs;

public class UpdateToDoTaskDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public bool? IsCompleted { get; set; }
}
