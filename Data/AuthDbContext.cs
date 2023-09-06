using AuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApi;

public class AuthDbContext: DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
    {
        
    }

    public DbSet<User> Users {get; set;} = default!;
}
