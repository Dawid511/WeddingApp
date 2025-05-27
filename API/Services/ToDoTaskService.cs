using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ToDoTaskService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<ToDoTask>> GetAllAsync()
    {
        return await _context.ToDoTasks.ToListAsync();
    }

    public async Task<ToDoTask?> GetByIdAsync(int id)
    {
        return await _context.ToDoTasks.FindAsync(id);
    }

    public async Task<ToDoTask> AddAsync(ToDoTask task)
    {
        _context.ToDoTasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> UpdateAsync(ToDoTask task)
    {
        _context.ToDoTasks.Update(task);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.ToDoTasks.FindAsync(id);
        if (task == null) return false;

        _context.ToDoTasks.Remove(task);
        return await _context.SaveChangesAsync() > 0;
    }
}
