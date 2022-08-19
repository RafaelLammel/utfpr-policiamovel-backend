using UTFPR.PoliciaMovel.Application.Interfaces.Repositories;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Application.Locations
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<List<Location>> GetAsync();
        Task<Location> GetAsync(string userId);
        Task UpdateAsync(string userId, Location updatedLocation);
    }
}