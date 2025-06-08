using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ToDoTaskService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<ToDoTask>> GetAllByUserIdAsync(int userId)
    {
        var wedding = await _context.Weddings
            .Include(w => w.ToDoList)
                .ThenInclude(t => t.Tasks)
            .FirstOrDefaultAsync(w => w.AppUserId == userId);

        return wedding?.ToDoList?.Tasks?.ToList() ?? [];
    }

    public async Task<ToDoTask?> AddAsync(int userId, string title)
    {
        var wedding = await _context.Weddings
            .Include(w => w.ToDoList)
            .FirstOrDefaultAsync(w => w.AppUserId == userId);

        var list = wedding?.ToDoList;
        if (list == null) return null;

        var task = new ToDoTask
        {
            Title = title,
            ToDoListId = list.Id
        };

        _context.ToDoTasks.Add(task);
        await _context.SaveChangesAsync();

        return task;
    }
}
