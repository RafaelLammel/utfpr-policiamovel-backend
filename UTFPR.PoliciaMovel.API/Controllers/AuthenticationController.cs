using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTFPR.PoliciaMovel.Application.Exceptions;
using UTFPR.PoliciaMovel.Application.Users;
using UTFPR.PoliciaMovel.Infrastructure.Authentication;

namespace UTFPR.PoliciaMovel.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenService _tokenService;
        
        public AuthenticationController(IUserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            try
            {
                LoginResponse user = await _userService.GetByLoginAndPassword(loginRequest);

                string token = _tokenService.GenerateToken(user);
                
                return Ok(new { AccessToken = token });
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errorMsg = "Algo deu errado", exceptionMessage = ex.Message });
            }
        }
    }
}