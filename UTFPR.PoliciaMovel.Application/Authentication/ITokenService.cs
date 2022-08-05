using UTFPR.PoliciaMovel.Application.Users;

namespace UTFPR.PoliciaMovel.Application.Authentication
{
    public interface ITokenService
    {
        string GenerateToken(LoginResponse user);
    }
}

