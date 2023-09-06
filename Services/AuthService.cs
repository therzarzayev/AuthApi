using AuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Services;

public class AuthService : IAuthService
{
    private readonly AuthDbContext _context;

    public AuthService(AuthDbContext context)
    {
        _context = context;
    }
    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<User>?> GetAllUser()
    {
        return await _context.Users.ToListAsync() ?? null;
    }

    public async Task<User?> GetUser(string email)
    {
        var usr = await _context.Users.FirstOrDefaultAsync(op=>op.Email==email);
        return usr ?? null;
    }
}
