namespace API.DTOs;

public class ToDoListDto
{
    public int Id { get; set; }
    public int WeddingId { get; set; }
    public List<ToDoTaskDto> Tasks { get; set; } = [];
}
