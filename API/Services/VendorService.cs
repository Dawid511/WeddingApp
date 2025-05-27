using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class VendorService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<Vendor>> GetAllAsync()
    {
        return await _context.Vendors
            .Include(v => v.Photos)
            .Include(v => v.AssignedToWeddings)
            .ToListAsync();
    }

    public async Task<Vendor?> GetByIdAsync(int id)
    {
        return await _context.Vendors
            .Include(v => v.Photos)
            .Include(v => v.AssignedToWeddings)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Vendor> AddAsync(Vendor vendor)
    {
        _context.Vendors.Add(vendor);
        await _context.SaveChangesAsync();
        return vendor;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var vendor = await _context.Vendors.FindAsync(id);
        if (vendor == null) return false;

        _context.Vendors.Remove(vendor);
        return await _context.SaveChangesAsync() > 0;
    }
}
