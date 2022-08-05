using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UTFPR.PoliciaMovel.Application.Users;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MongoDbContext mongoDbContext) : base(mongoDbContext)
        {
        }

        public async Task<User> FindByLoginAndPasswordAsync(string login, string password)
        {
            return await Collection.Find(x => x.Login == login && x.Password == password).FirstOrDefaultAsync();
        }

        public async Task<User> FindByLoginAsync(string login)
        {
            return await Collection.Find(x => x.Login == login).FirstOrDefaultAsync();
        }
    }
}
