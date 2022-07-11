using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SaveAsync(CreateUserRequest request)
        {
            var entity = new User()
            {
                Login = request.Login,
                Password = request.Password
            };

            await _userRepository.SaveAsync(entity);
        }
    }
}
