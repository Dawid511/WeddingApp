using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class PhotoService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<Photo>> GetAllAsync()
    {
        return await _context.Photos
            .Include(p => p.Vendor)
            .ToListAsync();
    }

    public async Task<Photo?> GetByIdAsync(int id)
    {
        return await _context.Photos
            .Include(p => p.Vendor)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Photo> AddAsync(Photo photo)
    {
        _context.Photos.Add(photo);
        await _context.SaveChangesAsync();
        return photo;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var photo = await _context.Photos.FindAsync(id);
        if (photo == null) return false;

        _context.Photos.Remove(photo);
        return await _context.SaveChangesAsync() > 0;
    }
}
