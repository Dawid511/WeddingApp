using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ExpenseItemService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<ExpenseItem>> GetAllAsync()
    {
        return await _context.ExpenseItems.Include(e => e.ExpenseList).ToListAsync();
    }

    public async Task<ExpenseItem?> GetByIdAsync(int id)
    {
        return await _context.ExpenseItems.Include(e => e.ExpenseList).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<ExpenseItem> AddAsync(ExpenseItem item)
    {
        _context.ExpenseItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> UpdateAsync(ExpenseItem item)
    {
        _context.ExpenseItems.Update(item);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.ExpenseItems.FindAsync(id);
        if (item == null) return false;

        _context.ExpenseItems.Remove(item);
        return await _context.SaveChangesAsync() > 0;
    }
}
