using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Application.Locations
{
    public interface ILocationService
    {
        Task SaveAsync(CreateLocationRequest request);
        Task<Location> GetAsync(string userId);
        Task UpdateAsync(string userId, Location updatedLocation);
    }
}
