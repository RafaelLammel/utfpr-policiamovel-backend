using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UTFPR.PoliciaMovel.Application.Locations;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Infrastructure.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(MongoDbContext mongoDbContext) : base(mongoDbContext)
        {
        }

        public async Task<Location> GetAsync(string id)
        {
            Location location = await Collection.Find(x => x.UserId == id).FirstOrDefaultAsync();
            return location;
        }

        public async Task UpdateAsync(string id, Location updatedLocation)
        {
            await Collection.ReplaceOneAsync(x => x.UserId == id, updatedLocation);
        }
    }
}