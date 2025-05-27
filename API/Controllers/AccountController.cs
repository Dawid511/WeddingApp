using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(DataContext context, ITokenService tokenService) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly ITokenService _tokenService = tokenService;

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.UserName.ToLower() == dto.Username.ToLower()))
            return BadRequest("Username is taken");

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            UserName = dto.Username,
            Role = Enum.Parse<UserRole>(dto.Role, true),
            DateofBirth = dto.DateOfBirth,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
            PasswordSalt = hmac.Key
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            Username = user.UserName,
            Role = user.Role.ToString(),
            Age = user.GetAge(),
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == dto.Username.ToLower());

        if (user == null)
            return Unauthorized("Invalid username or password");

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i])
                return Unauthorized("Invalid username or password");
        }

        return new UserDto
        {
            Id = user.Id,
            Username = user.UserName,
            Role = user.Role.ToString(),
            Age = user.GetAge(),
            Token = _tokenService.CreateToken(user)
        };
    }
}
