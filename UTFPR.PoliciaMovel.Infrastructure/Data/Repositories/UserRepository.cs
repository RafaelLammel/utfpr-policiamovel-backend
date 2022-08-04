using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UTFPR.PoliciaMovel.Application.Users;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<User> FindByLoginAndPasswordAsync(string login, string password)
        {
            return await _collection.Find(x => x.Login == login && x.Password == password).FirstOrDefaultAsync();
        }

        public async Task<User> FindByLoginAsync(string login)
        {
            return await _collection.Find(x => x.Login == login).FirstOrDefaultAsync();
        }
    }
}
