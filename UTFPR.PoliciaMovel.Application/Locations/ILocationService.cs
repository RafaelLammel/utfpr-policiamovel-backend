using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Application.Locations
{
    public interface ILocationService
    {
        Task SaveAsync(CreateLocationRequest request);
        Task UpdateAsync(string userId, UpdateLocationRequest updatedLocation);
        Task<List<GetLocationsRequest>> GetLocations();
    }
}
