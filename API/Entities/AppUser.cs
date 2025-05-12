using System;
using API.Extentions;
using API.Types;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required UserRole Role { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];

    public DateOnly DateofBirth { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public Wedding? Wedding { get; set; }


    public int GetAge()
    {
        return DateofBirth.CalculateAge();
    }
}
