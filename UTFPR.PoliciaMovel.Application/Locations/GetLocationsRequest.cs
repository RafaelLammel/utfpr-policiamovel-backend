using System.ComponentModel.DataAnnotations;

namespace UTFPR.PoliciaMovel.Application.Locations
{
    public class GetLocationsRequest
    {
        public string UserId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
