using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ToDoListService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<ToDoList>> GetAllAsync()
    {
        return await _context.ToDoLists
            .Include(l => l.Tasks)
            .ToListAsync();
    }

    public async Task<ToDoList?> GetByIdAsync(int id)
    {
        return await _context.ToDoLists
            .Include(l => l.Tasks)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<ToDoList> AddAsync(ToDoList list)
    {
        _context.ToDoLists.Add(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var list = await _context.ToDoLists.FindAsync(id);
        if (list == null) return false;

        _context.ToDoLists.Remove(list);
        return await _context.SaveChangesAsync() > 0;
    }
}
