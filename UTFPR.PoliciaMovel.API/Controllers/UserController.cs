using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTFPR.PoliciaMovel.Application.Exceptions;
using UTFPR.PoliciaMovel.Application.Users;

namespace UTFPR.PoliciaMovel.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                createUserRequest.Password = _userService.HashPassword(createUserRequest.Password);
                await _userService.SaveAsync(createUserRequest);
                return Created("", null);
            }
            catch (InvalidUserLoginException ex)
            {
                return BadRequest(new { errorMsg = ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { errorMsg = "Algo deu errado", exceptionMessage = ex.Message });
            }
        }
    }
}
