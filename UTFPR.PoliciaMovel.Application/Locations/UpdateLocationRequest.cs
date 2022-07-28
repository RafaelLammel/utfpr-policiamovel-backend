using System.ComponentModel.DataAnnotations;
namespace UTFPR.PoliciaMovel.Application.Locations
{
    public class UpdateLocationRequest
    {
        [Required]
        public string longitude { get; set; }
        [Required]
        public string latitude { get; set; }
    }
}
