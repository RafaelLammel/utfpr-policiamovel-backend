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
            UserId = request.userId,
            Latitute = request.latitude,
            Longitude = request.longitude
        };

        await _locationRepository.SaveAsync(entity);
    }

    public async Task<Location> GetAsync(string userId)
    {
        Location location = await _locationRepository.GetAsync(userId);
        return location;
    }


    public async Task UpdateAsync(string userId, Location updatedLocation)
    {
        await _locationRepository.UpdateAsync(userId, updatedLocation);
    }
}
