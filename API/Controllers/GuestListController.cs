using API.DTOs;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuestListsController(GuestListService service) : ControllerBase
{
    private readonly GuestListService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<GuestListDto>>> GetAll()
    {
        var lists = await _service.GetAllAsync();

        var dtos = lists.Select(gl => new GuestListDto
        {
            Id = gl.Id,
            WeddingId = gl.WeddingId,
            Guests = gl.Guests.Select(g => new GuestDto
            {
                Id = g.Id,
                GuestListId = g.GuestListId,
                FullName = g.FullName,
                Email = g.Email,
                PhoneNumber = g.PhoneNumber,
                Notes = g.Notes,
                Status = g.pendingStatus.ToString()
            }).ToList()
        }).ToList();

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GuestListDto>> GetById(int id)
    {
        var list = await _service.GetByIdAsync(id);
        if (list == null) return NotFound();

        return Ok(new GuestListDto
        {
            Id = list.Id,
            WeddingId = list.WeddingId,
            Guests = list.Guests.Select(g => new GuestDto
            {
                Id = g.Id,
                GuestListId = g.GuestListId,
                FullName = g.FullName,
                Email = g.Email,
                PhoneNumber = g.PhoneNumber,
                Notes = g.Notes,
                Status = g.pendingStatus.ToString()
            }).ToList()
        });
    }

    [HttpPost]
    public async Task<ActionResult<GuestListDto>> Create(CreateGuestListDto dto)
    {
        var list = new GuestList
        {
            WeddingId = dto.WeddingId
        };

        var added = await _service.AddAsync(list);

        return CreatedAtAction(nameof(GetById), new { id = added.Id }, new GuestListDto
        {
            Id = added.Id,
            WeddingId = added.WeddingId,
            Guests = []
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
