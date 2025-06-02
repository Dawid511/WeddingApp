namespace API.Entities;

public class ToDoList // List of todos for single wedding
{
    public int Id { get; set; }

    public int WeddingId { get; set; }
    public Wedding Wedding { get; set; } = null!;

    public ICollection<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
}
