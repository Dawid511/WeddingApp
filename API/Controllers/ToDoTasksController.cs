using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ToDoTasksController(ToDoTaskService service) : ControllerBase
{
    private readonly ToDoTaskService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<ToDoTaskDto>>> GetAll()
    {
        var userIdStr = User.FindFirst("id")?.Value;
        if (userIdStr == null) return Unauthorized();

        var userId = int.Parse(userIdStr);
        var tasks = await _service.GetAllByUserIdAsync(userId);

        var dtos = tasks.Select(t => new ToDoTaskDto
        {
            Id = t.Id,
            Title = t.Title,
            IsCompleted = t.IsCompleted
        }).ToList();

        return Ok(dtos);
    }

    [HttpPost]
    public async Task<ActionResult<ToDoTaskDto>> Create(CreateToDoTaskDto dto)
    {
        var userIdStr = User.FindFirst("id")?.Value;
        if (userIdStr == null) return Unauthorized();

        var userId = int.Parse(userIdStr);

        var task = await _service.AddAsync(userId, dto.Title);
        if (task == null) return BadRequest("Brak przypisanej listy ToDo");

        return CreatedAtAction(nameof(GetAll), new { }, new ToDoTaskDto
        {
            Id = task.Id,
            Title = task.Title,
            IsCompleted = task.IsCompleted
        });
    }
}
