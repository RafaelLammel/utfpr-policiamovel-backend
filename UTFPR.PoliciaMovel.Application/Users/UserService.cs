using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using UTFPR.PoliciaMovel.Application.Exceptions;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string HashPassword(string password)
        {
            var salt = _configuration.GetValue<string>("Salt");

            using var sha256 = SHA256.Create();

            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        public async Task SaveAsync(CreateUserRequest request)
        {
            User user = await _userRepository.FindByLoginAsync(request.Login);

            if (user != null)
                throw new InvalidUserLoginException("Já existe um usuário com este Login");
            
            var entity = new User()
            {
                Login = request.Login,
                Password = request.Password
            };

            await _userRepository.SaveAsync(entity);
        }
    }
}
