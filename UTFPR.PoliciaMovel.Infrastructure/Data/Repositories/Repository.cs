using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UTFPR.PoliciaMovel.Application.Interfaces.Repositories;

namespace UTFPR.PoliciaMovel.Infrastructure.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly IMongoCollection<T> Collection;

        protected Repository(MongoDbContext mongoDbContext)
        {
            Collection = mongoDbContext.GetCollection<T>(typeof(T).Name);
        }

        public async Task SaveAsync(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }



    }
}
