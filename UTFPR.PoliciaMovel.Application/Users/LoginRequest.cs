using System.ComponentModel.DataAnnotations;

namespace UTFPR.PoliciaMovel.Application.Users
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Password { get; set; }
    }
}