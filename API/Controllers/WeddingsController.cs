using API.DTOs;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeddingsController(WeddingService weddingService) : ControllerBase
{
    private readonly WeddingService _weddingService = weddingService;

    [HttpGet]
    public async Task<ActionResult<List<WeddingDto>>> GetAll()
    {
        var weddings = await _weddingService.GetAllAsync();
        var dtos = weddings.Select(w => new WeddingDto
        {
            Id = w.Id,
            AppUserId = w.AppUserId,
            Title = w.Title,
            WeddingDate = w.WeddingDate,
            Location = w.Location,
            CreatedAt = w.CreatedAt
        }).ToList();

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeddingDto>> GetById(int id)
    {
        var wedding = await _weddingService.GetByIdAsync(id);
        if (wedding == null) return NotFound();

        return Ok(new WeddingDto
        {
            Id = wedding.Id,
            AppUserId = wedding.AppUserId,
            Title = wedding.Title,
            WeddingDate = wedding.WeddingDate,
            Location = wedding.Location,
            CreatedAt = wedding.CreatedAt
        });
    }

    [HttpPost]
    public async Task<ActionResult<WeddingDto>> Create(CreateWeddingDto dto)
    {
        var wedding = new Wedding
        {
            AppUserId = dto.AppUserId,
            Title = dto.Title,
            WeddingDate = dto.WeddingDate,
            Location = dto.Location
        };

        var created = await _weddingService.AddAsync(wedding);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new WeddingDto
        {
            Id = created.Id,
            AppUserId = created.AppUserId,
            Title = created.Title,
            WeddingDate = created.WeddingDate,
            Location = created.Location,
            CreatedAt = created.CreatedAt
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _weddingService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
