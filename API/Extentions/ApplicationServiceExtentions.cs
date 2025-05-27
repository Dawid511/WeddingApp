using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions;

public static class ApplicationServiceExtentions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<GuestService>();
        services.AddScoped<GuestListService>();
        services.AddScoped<WeddingService>();
        services.AddScoped<ExpenseItemService>();
        services.AddScoped<ExpenseListService>();
        services.AddScoped<VendorService>();
        services.AddScoped<PhotoService>();
        services.AddScoped<ToDoTaskService>();
        services.AddScoped<ToDoListService>();



        return services;
    }
}