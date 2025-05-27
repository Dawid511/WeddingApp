using API.DTOs;
using API.Entities;
using API.Services;
using API.Types;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendorsController(VendorService vendorService) : ControllerBase
{
    private readonly VendorService _service = vendorService;

    [HttpGet]
    public async Task<ActionResult<List<VendorDto>>> GetAll()
    {
        var vendors = await _service.GetAllAsync();

        var result = vendors.Select(v => new VendorDto
        {
            Id = v.Id,
            AppUserId = v.AppUserId,
            Category = v.Category.ToString(),
            CompanyName = v.CompanyName,
            Description = v.Description,
            WebsiteUrl = v.WebsiteUrl,
            Phone = v.Phone,
            Email = v.Email
        }).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VendorDto>> GetById(int id)
    {
        var vendor = await _service.GetByIdAsync(id);
        if (vendor == null) return NotFound();

        return Ok(new VendorDto
        {
            Id = vendor.Id,
            AppUserId = vendor.AppUserId,
            Category = vendor.Category.ToString(),
            CompanyName = vendor.CompanyName,
            Description = vendor.Description,
            WebsiteUrl = vendor.WebsiteUrl,
            Phone = vendor.Phone,
            Email = vendor.Email
        });
    }

    [HttpPost]
    public async Task<ActionResult<VendorDto>> Create(CreateVendorDto dto)
    {
        if (!Enum.TryParse<VendorCategory>(dto.Category, true, out var category))
            return BadRequest("Invalid category");

        var vendor = new Vendor
        {
            AppUserId = dto.AppUserId,
            Category = category,
            CompanyName = dto.CompanyName,
            Description = dto.Description,
            WebsiteUrl = dto.WebsiteUrl,
            Phone = dto.Phone,
            Email = dto.Email
        };

        var created = await _service.AddAsync(vendor);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new VendorDto
        {
            Id = created.Id,
            AppUserId = created.AppUserId,
            Category = created.Category.ToString(),
            CompanyName = created.CompanyName,
            Description = created.Description,
            WebsiteUrl = created.WebsiteUrl,
            Phone = created.Phone,
            Email = created.Email
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
