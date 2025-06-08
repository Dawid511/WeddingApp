using API.DTOs;
using API.Entities;
using API.Services;
using API.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GuestsController(GuestService guestService) : ControllerBase
{
    private readonly GuestService _guestService = guestService;

    [HttpGet]
    public async Task<ActionResult<List<GuestDto>>> GetAll()
    {
        var userIdStr = User.FindFirst("id")?.Value;
        if (userIdStr == null) return Unauthorized();

        int userId = int.Parse(userIdStr);
        var guests = await _guestService.GetAllByUserIdAsync(userId);

        var result = guests.Select(g => new GuestDto
        {
            Id = g.Id,
            GuestListId = g.GuestListId,
            FullName = g.FullName,
            Email = g.Email,
            PhoneNumber = g.PhoneNumber,
            Count = g.Count,
            Notes = g.Notes,
            Status = g.pendingStatus.ToString()
        }).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GuestDto>> GetById(int id)
    {
        var guest = await _guestService.GetByIdAsync(id);
        if (guest == null) return NotFound();

        var dto = new GuestDto
        {
            Id = guest.Id,
            GuestListId = guest.GuestListId,
            FullName = guest.FullName,
            Email = guest.Email,
            PhoneNumber = guest.PhoneNumber,
            Count = guest.Count,
            Notes = guest.Notes,
            Status = guest.pendingStatus.ToString()
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<GuestDto>> Create(CreateGuestDto dto)
    {
        var userIdStr = User.FindFirst("id")?.Value;
        if (userIdStr == null) return Unauthorized();

        int userId = int.Parse(userIdStr);

        var guest = new Guest
        {
            FullName = dto.FullName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Count = dto.Count,
            Notes = dto.Notes
        };

        var added = await _guestService.AddAsync(userId, guest);
        if (added == null) return BadRequest("Nie znaleziono ślubu lub listy gości dla tego użytkownika.");

        return CreatedAtAction(nameof(GetById), new { id = added.Id }, new GuestDto
        {
            Id = added.Id,
            GuestListId = added.GuestListId,
            FullName = added.FullName,
            Email = added.Email,
            PhoneNumber = added.PhoneNumber,
            Count = added.Count,
            Notes = added.Notes,
            Status = added.pendingStatus.ToString()
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateGuestDto dto)
    {
        var guest = await _guestService.GetByIdAsync(id);
        if (guest == null) return NotFound();

        if (dto.FullName is not null) guest.FullName = dto.FullName;
        if (dto.Email is not null) guest.Email = dto.Email;
        if (dto.PhoneNumber is not null) guest.PhoneNumber = dto.PhoneNumber;
        if (dto.Count is not null) guest.Count = dto.Count.Value;
        if (dto.Notes is not null) guest.Notes = dto.Notes;
        if (dto.Status is not null && Enum.TryParse(dto.Status, out Status status))
            guest.pendingStatus = status;

        var updated = await _guestService.UpdateAsync(guest);
        return updated ? NoContent() : StatusCode(500, "Update failed");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _guestService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
