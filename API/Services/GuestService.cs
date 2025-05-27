using API.Data;
using API.Entities;
using API.Types;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class GuestService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<Guest>> GetAllAsync()
    {
        return await _context.Guests.Include(g => g.GuestList).ToListAsync();
    }

    public async Task<Guest?> GetByIdAsync(int id)
    {
        return await _context.Guests.Include(g => g.GuestList).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Guest> AddAsync(Guest guest)
    {
        _context.Guests.Add(guest);
        await _context.SaveChangesAsync();
        return guest;
    }

    public async Task<bool> UpdateAsync(Guest guest)
    {
        _context.Guests.Update(guest);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var guest = await _context.Guests.FindAsync(id);
        if (guest == null) return false;

        _context.Guests.Remove(guest);
        return await _context.SaveChangesAsync() > 0;
    }
}
