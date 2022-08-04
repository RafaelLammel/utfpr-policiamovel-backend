using Microsoft.Extensions.Configuration;
using UTFPR.PoliciaMovel.Application.Locations;
using UTFPR.PoliciaMovel.Domain.Entities;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IConfiguration _configuration;

    public LocationService(ILocationRepository locationRepository, IConfiguration configuration)
    {
        _locationRepository = locationRepository;
        _configuration = configuration;
    }
    public async Task SaveAsync(CreateLocationRequest request)
    {
        var entity = new Location()
        {
            UserId = request.UserId,
            Latitude = request.Latitude,
            Longitude = request.Longitude
        };

        await _locationRepository.SaveAsync(entity);
    }

    public async Task<Location> GetAsync(string userId)
    {
        Location location = await _locationRepository.GetAsync(userId);
        return location;
    }

    public async Task UpdateAsync(string userId, UpdateLocationRequest updatedLocation)
    {
        Location location = await _locationRepository.GetAsync(userId);
        location.Latitude = updatedLocation.Latitude;
        location.Longitude = updatedLocation.Longitude;
        await _locationRepository.UpdateAsync(userId, location);
    }
}
