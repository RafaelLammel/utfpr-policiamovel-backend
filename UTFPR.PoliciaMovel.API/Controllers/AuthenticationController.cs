using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTFPR.PoliciaMovel.Application.Users;
using UTFPR.PoliciaMovel.Domain.Entities;
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
            this._userService = userService;
            this._tokenService = tokenService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            User user = await _userService.GetByLoginAndPassword(loginRequest);
            if (user == null)
            {
                return NotFound();
            }
            string token = _tokenService.GenerateToken(user);
            return Ok(new { AccessToken = token });
        }
    }
}