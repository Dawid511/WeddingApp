using API.DTOs;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoTasksController(ToDoTaskService service) : ControllerBase
{
    private readonly ToDoTaskService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<ToDoTaskDto>>> GetAll()
    {
        var tasks = await _service.GetAllAsync();
        var dtos = tasks.Select(t => new ToDoTaskDto
        {
            Id = t.Id,
            ToDoListId = t.ToDoListId,
            Title = t.Title,
            Description = t.Description,
            DueDate = t.DueDate,
            IsCompleted = t.IsCompleted
        }).ToList();

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoTaskDto>> GetById(int id)
    {
        var task = await _service.GetByIdAsync(id);
        if (task == null) return NotFound();

        return Ok(new ToDoTaskDto
        {
            Id = task.Id,
            ToDoListId = task.ToDoListId,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        });
    }

    [HttpPost]
    public async Task<ActionResult<ToDoTaskDto>> Create(CreateToDoTaskDto dto)
    {
        var task = new ToDoTask
        {
            ToDoListId = dto.ToDoListId,
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate
        };

        var created = await _service.AddAsync(task);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ToDoTaskDto
        {
            Id = created.Id,
            ToDoListId = created.ToDoListId,
            Title = created.Title,
            Description = created.Description,
            DueDate = created.DueDate,
            IsCompleted = created.IsCompleted
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateToDoTaskDto dto)
    {
        var task = await _service.GetByIdAsync(id);
        if (task == null) return NotFound();

        if (dto.Title is not null) task.Title = dto.Title;
        if (dto.Description is not null) task.Description = dto.Description;
        if (dto.DueDate is not null) task.DueDate = dto.DueDate;
        if (dto.IsCompleted is not null) task.IsCompleted = dto.IsCompleted.Value;

        var updated = await _service.UpdateAsync(task);
        return updated ? NoContent() : StatusCode(500, "Update failed");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
