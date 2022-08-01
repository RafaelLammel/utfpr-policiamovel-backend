using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UTFPR.PoliciaMovel.Application.Interfaces.Repositories;

namespace UTFPR.PoliciaMovel.Infrastructure.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        public Repository(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetValue<string>("ConnectionString"));

            var mondoDatabase = mongoClient.GetDatabase(configuration.GetValue<string>("Database"));

            _collection = mondoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public async Task SaveAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }
    }
}
