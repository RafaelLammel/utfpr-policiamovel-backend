using System.ComponentModel.DataAnnotations;

namespace UTFPR.PoliciaMovel.Application.Users
{
    public class LoginRequest
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}