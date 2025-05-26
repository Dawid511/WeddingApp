using API.DTOs;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseListsController(ExpenseListService service) : ControllerBase
{
    private readonly ExpenseListService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<ExpenseListDto>>> GetAll()
    {
        var lists = await _service.GetAllAsync();

        var result = lists.Select(list => new ExpenseListDto
        {
            Id = list.Id,
            WeddingId = list.WeddingId,
            Items = list.Items.Select(item => new ExpenseItemDto
            {
                Id = item.Id,
                ExpenseListId = item.ExpenseListId,
                Name = item.Name,
                EstimatedCost = item.EstimatedCost,
                ActualCost = item.ActualCost,
                IsPaid = item.IsPaid,
                Notes = item.Notes
            }).ToList()
        }).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseListDto>> GetById(int id)
    {
        var list = await _service.GetByIdAsync(id);
        if (list == null) return NotFound();

        return Ok(new ExpenseListDto
        {
            Id = list.Id,
            WeddingId = list.WeddingId,
            Items = list.Items.Select(item => new ExpenseItemDto
            {
                Id = item.Id,
                ExpenseListId = item.ExpenseListId,
                Name = item.Name,
                EstimatedCost = item.EstimatedCost,
                ActualCost = item.ActualCost,
                IsPaid = item.IsPaid,
                Notes = item.Notes
            }).ToList()
        });
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseListDto>> Create(CreateExpenseListDto dto)
    {
        var list = new ExpenseList
        {
            WeddingId = dto.WeddingId
        };

        var created = await _service.AddAsync(list);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ExpenseListDto
        {
            Id = created.Id,
            WeddingId = created.WeddingId,
            Items = []
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
