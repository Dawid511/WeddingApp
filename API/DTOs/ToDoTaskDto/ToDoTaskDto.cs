namespace API.DTOs;

public class ToDoTaskDto
{
    public int Id { get; set; }
    public int ToDoListId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
}
