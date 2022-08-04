using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UTFPR.PoliciaMovel.Application.Locations;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Infrastructure.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private readonly IMongoCollection<Location> _collection;
        public LocationRepository(IConfiguration configuration) : base(configuration)
        {
            var mongoClient = new MongoClient(configuration.GetValue<string>("ConnectionString"));

            var mondoDatabase = mongoClient.GetDatabase(configuration.GetValue<string>("Database"));

            _collection = mondoDatabase.GetCollection<Location>(typeof(Location).Name);

        }

        public async Task<Location> GetAsync(string id)
        {
            Location location = await _collection.Find(x => x.UserId == id).FirstOrDefaultAsync();
            return location;
        }

        public async Task UpdateAsync(string id, Location updatedLocation)
        {
            await _collection.ReplaceOneAsync(x => x.UserId == id, updatedLocation);
        }
    }
}