using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class WeddingService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<Wedding>> GetAllAsync()
    {
        return await _context.Weddings
            .Include(w => w.GuestList)
            .Include(w => w.ExpenseList)
            .Include(w => w.SelectedVendors)
            .ToListAsync();
    }

    public async Task<Wedding?> GetByIdAsync(int id)
    {
        return await _context.Weddings
            .Include(w => w.GuestList)
            .Include(w => w.ExpenseList)
            .Include(w => w.SelectedVendors)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<Wedding> AddAsync(Wedding wedding)
    {
        _context.Weddings.Add(wedding);
        await _context.SaveChangesAsync();
        return wedding;
    }

    public async Task<bool> UpdateAsync(Wedding wedding)
    {
        _context.Weddings.Update(wedding);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var wedding = await _context.Weddings.FindAsync(id);
        if (wedding == null) return false;

        _context.Weddings.Remove(wedding);
        return await _context.SaveChangesAsync() > 0;
    }
}
