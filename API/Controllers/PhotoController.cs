using API.DTOs;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhotosController(PhotoService service) : ControllerBase
{
    private readonly PhotoService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<PhotoDto>>> GetAll()
    {
        var photos = await _service.GetAllAsync();

        var result = photos.Select(p => new PhotoDto
        {
            Id = p.Id,
            Url = p.Url,
            IsMain = p.IsMain,
            PublicId = p.publicId,
            VendorID = p.VendorID
        }).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PhotoDto>> GetById(int id)
    {
        var photo = await _service.GetByIdAsync(id);
        if (photo == null) return NotFound();

        return Ok(new PhotoDto
        {
            Id = photo.Id,
            Url = photo.Url,
            IsMain = photo.IsMain,
            PublicId = photo.publicId,
            VendorID = photo.VendorID
        });
    }

    [HttpPost]
    public async Task<ActionResult<PhotoDto>> Create(CreatePhotoDto dto)
    {
        var photo = new Photo
        {
            Url = dto.Url,
            IsMain = dto.IsMain,
            publicId = dto.PublicId,
            VendorID = dto.VendorID
        };

        var created = await _service.AddAsync(photo);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new PhotoDto
        {
            Id = created.Id,
            Url = created.Url,
            IsMain = created.IsMain,
            PublicId = created.publicId,
            VendorID = created.VendorID
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
