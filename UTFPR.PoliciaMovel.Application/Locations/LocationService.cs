using UTFPR.PoliciaMovel.Application.Exceptions;
using UTFPR.PoliciaMovel.Application.Users;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Application.Locations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IUserRepository _userRepository;

        public LocationService(ILocationRepository locationRepository, IUserRepository userRepository)
        {
            _locationRepository = locationRepository;
            _userRepository = userRepository;
        }

        public async Task SaveAsync(CreateLocationRequest request)
        {
            var entity = new Location()
            {
                UserId = request.UserId,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                LastPutDate = DateTime.UtcNow
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
            location.LastPutDate = DateTime.UtcNow;

            await _locationRepository.UpdateAsync(userId, location);
        }

        public async Task<List<GetLocationsRequest>> GetLocations()
        {
            List<Location> locations = await _locationRepository.GetAsync();
            List<GetLocationsRequest> locationsView = new List<GetLocationsRequest>();

            foreach(Location location in locations){
                GetLocationsRequest locationView = new GetLocationsRequest(){
                    UserId = location.UserId,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    LastPutDate = location.LastPutDate
                };
                User userLogin = await _userRepository.FindById(location.UserId);
                locationView.Login = userLogin.Login;
                locationsView.Add(locationView);
            }
            
            return locationsView;
        }
    }
}