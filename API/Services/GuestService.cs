using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class GuestService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<Guest>> GetAllByUserIdAsync(int userId)
    {
        var guestList = await _context.GuestLists
            .Include(gl => gl.Guests)
            .FirstOrDefaultAsync(gl => gl.Wedding.AppUserId == userId);

        return guestList?.Guests?.ToList() ?? [];
    }

    public async Task<Guest?> GetByIdAsync(int id)
    {
        return await _context.Guests
            .Include(g => g.GuestList)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Guest?> AddAsync(int userId, Guest guest)
    {
        var wedding = await _context.Weddings
            .Include(w => w.GuestList)
            .FirstOrDefaultAsync(w => w.AppUserId == userId);

        if (wedding == null)
            return null;

        // Tworzenie GuestList jeśli jeszcze nie istnieje
        if (wedding.GuestList == null)
        {
            var newList = new GuestList { WeddingId = wedding.Id };
            _context.GuestLists.Add(newList);
            await _context.SaveChangesAsync();

            wedding.GuestList = newList;
        }

        guest.GuestListId = wedding.GuestList.Id;

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
