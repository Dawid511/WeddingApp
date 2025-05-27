using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class GuestListService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<GuestList>> GetAllAsync()
    {
        return await _context.GuestLists
            .Include(gl => gl.Guests)
            .ToListAsync();
    }

    public async Task<GuestList?> GetByIdAsync(int id)
    {
        return await _context.GuestLists
            .Include(gl => gl.Guests)
            .FirstOrDefaultAsync(gl => gl.Id == id);
    }

    public async Task<GuestList> AddAsync(GuestList guestList)
    {
        _context.GuestLists.Add(guestList);
        await _context.SaveChangesAsync();
        return guestList;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var guestList = await _context.GuestLists.FindAsync(id);
        if (guestList == null) return false;

        _context.GuestLists.Remove(guestList);
        return await _context.SaveChangesAsync() > 0;
    }
}
