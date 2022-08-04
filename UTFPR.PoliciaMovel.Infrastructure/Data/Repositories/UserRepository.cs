using Microsoft.Extensions.Configuration;
using UTFPR.PoliciaMovel.Application.Users;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
