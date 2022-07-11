namespace UTFPR.PoliciaMovel.Application.Users
{
    public interface IUserService
    {
        Task SaveAsync(CreateUserRequest request);
        string HashPassword(string password);
    }
}
