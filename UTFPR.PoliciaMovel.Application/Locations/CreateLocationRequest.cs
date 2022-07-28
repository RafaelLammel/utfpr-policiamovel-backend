using System.ComponentModel.DataAnnotations;
namespace UTFPR.PoliciaMovel.Application.Locations
{
    public class CreateLocationRequest
    {
        [Required]
        public string userId {get; set;}
        [Required]
        public string longitude { get; set; }
        [Required]
        public string latitude { get; set; }
    }
}
