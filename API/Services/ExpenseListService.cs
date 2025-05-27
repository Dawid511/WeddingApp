using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ExpenseListService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<ExpenseList>> GetAllAsync()
    {
        return await _context.ExpenseLists
            .Include(el => el.Items)
            .ToListAsync();
    }

    public async Task<ExpenseList?> GetByIdAsync(int id)
    {
        return await _context.ExpenseLists
            .Include(el => el.Items)
            .FirstOrDefaultAsync(el => el.Id == id);
    }

    public async Task<ExpenseList> AddAsync(ExpenseList list)
    {
        _context.ExpenseLists.Add(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var list = await _context.ExpenseLists.FindAsync(id);
        if (list == null) return false;

        _context.ExpenseLists.Remove(list);
        return await _context.SaveChangesAsync() > 0;
    }
}
