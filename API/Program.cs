using API.Data;
using API.Extentions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x =>
    x.AllowAnyHeader()
     .AllowAnyMethod()
     .WithOrigins("http://localhost:4200", "https://localhost:4200"));


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

using var scope = app.Services.CreateScope();
// var services = scope.ServiceProvider;
// try
// {
//     var context = services.GetRequiredService<DataContext>();
//     await context.Database.MigrateAsync();
//     await Seed.SeedUsers(context);
// }
// catch (Exception ex)
// {
//     var logger = services.GetRequiredService<ILogger<Program>>();
//     logger.LogError(ex, "error during migration");
// }

app.Run();