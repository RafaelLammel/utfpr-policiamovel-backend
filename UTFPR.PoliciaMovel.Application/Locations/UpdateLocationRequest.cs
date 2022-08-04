using System.ComponentModel.DataAnnotations;
namespace UTFPR.PoliciaMovel.Application.Locations
{
    public class UpdateLocationRequest
    {
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }
}
