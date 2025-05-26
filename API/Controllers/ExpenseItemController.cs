using API.DTOs;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseItemsController(ExpenseItemService service) : ControllerBase
{
    private readonly ExpenseItemService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<ExpenseItemDto>>> GetAll()
    {
        var items = await _service.GetAllAsync();

        var result = items.Select(item => new ExpenseItemDto
        {
            Id = item.Id,
            ExpenseListId = item.ExpenseListId,
            Name = item.Name,
            EstimatedCost = item.EstimatedCost,
            ActualCost = item.ActualCost,
            IsPaid = item.IsPaid,
            Notes = item.Notes
        }).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseItemDto>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();

        return Ok(new ExpenseItemDto
        {
            Id = item.Id,
            ExpenseListId = item.ExpenseListId,
            Name = item.Name,
            EstimatedCost = item.EstimatedCost,
            ActualCost = item.ActualCost,
            IsPaid = item.IsPaid,
            Notes = item.Notes
        });
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseItemDto>> Create(CreateExpenseItemDto dto)
    {
        var item = new ExpenseItem
        {
            ExpenseListId = dto.ExpenseListId,
            Name = dto.Name,
            EstimatedCost = dto.EstimatedCost,
            ActualCost = dto.ActualCost,
            IsPaid = dto.IsPaid,
            Notes = dto.Notes
        };

        var created = await _service.AddAsync(item);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ExpenseItemDto
        {
            Id = created.Id,
            ExpenseListId = created.ExpenseListId,
            Name = created.Name,
            EstimatedCost = created.EstimatedCost,
            ActualCost = created.ActualCost,
            IsPaid = created.IsPaid,
            Notes = created.Notes
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateExpenseItemDto dto)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();

        if (dto.Name is not null) item.Name = dto.Name;
        if (dto.EstimatedCost is not null) item.EstimatedCost = dto.EstimatedCost.Value;
        if (dto.ActualCost is not null) item.ActualCost = dto.ActualCost;
        if (dto.IsPaid is not null) item.IsPaid = dto.IsPaid.Value;
        if (dto.Notes is not null) item.Notes = dto.Notes;

        var updated = await _service.UpdateAsync(item);
        return updated ? NoContent() : StatusCode(500, "Update failed");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
