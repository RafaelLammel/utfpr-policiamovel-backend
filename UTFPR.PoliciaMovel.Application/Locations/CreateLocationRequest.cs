using System.ComponentModel.DataAnnotations;
namespace UTFPR.PoliciaMovel.Application.Locations
{
    public class CreateLocationRequest
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }
}
