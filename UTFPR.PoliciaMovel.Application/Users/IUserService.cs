using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Application.Users
{
    public interface IUserService
    {
        Task<User> SaveAsync(CreateUserRequest request);
        string HashPassword(string password);
        Task<LoginResponse> GetByLoginAndPassword(LoginRequest request);
    }
}
