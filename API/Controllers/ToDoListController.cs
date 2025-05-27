using API.DTOs;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListsController(ToDoListService service) : ControllerBase
{
    private readonly ToDoListService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<ToDoListDto>>> GetAll()
    {
        var lists = await _service.GetAllAsync();

        var result = lists.Select(list => new ToDoListDto
        {
            Id = list.Id,
            WeddingId = list.WeddingId,
            Tasks = list.Tasks.Select(task => new ToDoTaskDto
            {
                Id = task.Id,
                ToDoListId = task.ToDoListId,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            }).ToList()
        }).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoListDto>> GetById(int id)
    {
        var list = await _service.GetByIdAsync(id);
        if (list == null) return NotFound();

        return Ok(new ToDoListDto
        {
            Id = list.Id,
            WeddingId = list.WeddingId,
            Tasks = list.Tasks.Select(task => new ToDoTaskDto
            {
                Id = task.Id,
                ToDoListId = task.ToDoListId,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            }).ToList()
        });
    }

    [HttpPost]
    public async Task<ActionResult<ToDoListDto>> Create(CreateToDoListDto dto)
    {
        var list = new ToDoList
        {
            WeddingId = dto.WeddingId
        };

        var created = await _service.AddAsync(list);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ToDoListDto
        {
            Id = created.Id,
            WeddingId = created.WeddingId,
            Tasks = []
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
