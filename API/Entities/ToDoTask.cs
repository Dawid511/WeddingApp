namespace API.Entities;

public class ToDoTask   // single to do task
{
    public int Id { get; set; }

    public int ToDoListId { get; set; }
    public ToDoList ToDoList { get; set; } = null!;

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; } = false;
}
