using UTFPR.PoliciaMovel.Application.Exceptions;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Application.Locations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
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

        public async Task UpdateAsync(string userId, UpdateLocationRequest updatedLocation)
        {
            Location location = await _locationRepository.GetAsync(userId);

            if (location == null)
                throw new LocationNotFoundByUserIdException("Nenhuma localização encontrada para o usuário em questão");

            location.Latitude = updatedLocation.Latitude;
            location.Longitude = updatedLocation.Longitude;

            await _locationRepository.UpdateAsync(userId, location);
        }

        public async Task<List<GetLocationsRequest>> GetLocations()
        {
            List<Location> locations = await _locationRepository.GetAsync();
            List<GetLocationsRequest> locationsView = locations.Select(x => new GetLocationsRequest()
            {
                UserId = x.UserId,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            }).ToList();
            return locationsView;
        }
    }
}