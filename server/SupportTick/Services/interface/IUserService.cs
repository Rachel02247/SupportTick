using static SupportTick.Models.request.Auth;
using SupportTick.Models;

namespace SupportTick.Services
{
    public interface IUserService
    {
        List<User> GetUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(RegisterModel user);
    }
}
