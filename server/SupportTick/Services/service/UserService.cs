
using static SupportTick.Models.request.Auth;
using SupportTick.Models;
using SupportTick.DataAccess;
using Org.BouncyCastle.Crypto.Generators;

namespace SupportTick.Services.service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly DataContext _context;
        public UserService( ILogger<UserService> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
            _context.LoadData();
        }

        public List<User> GetUsersAsync() =>  _context.Users.ToList();
        public async Task<User> GetUserByEmailAsync(string email) =>  _context.Users.SingleOrDefault(u => u.Email == email);
        public async Task<User> CreateUserAsync(RegisterModel model)
        {
            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);


                User user = new User()
                {
                    UserId = _context.Users.Last().UserId + 1,
                    FullName = model.Name,
                    Email = model.Email,
                    Password = hashedPassword
                };

                _context.Users.Add(user);
                 _context.SaveData();
                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e + " ERROR: create user failed");
            }
            return new User();
        }
    }
}
