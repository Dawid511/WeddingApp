namespace API.DTOs;

public class CreateToDoTaskDto
{
    public int ToDoListId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
}
