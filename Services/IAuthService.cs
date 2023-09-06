using AuthApi.Models;

namespace AuthApi.Services;

public interface IAuthService
{
    Task<IList<User>?> GetAllUser();
    Task<User?> GetUser(string email);
    Task AddUser(User user);
}
