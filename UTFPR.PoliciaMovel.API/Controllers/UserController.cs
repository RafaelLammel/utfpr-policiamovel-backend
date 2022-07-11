using Microsoft.AspNetCore.Mvc;
using UTFPR.PoliciaMovel.Application.Users;

namespace UTFPR.PoliciaMovel.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
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
                await _userService.SaveAsync(createUserRequest);
                return Created("", null);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
