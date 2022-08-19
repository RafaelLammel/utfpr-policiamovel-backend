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

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <response code="201">Usuário criado com sucesso</response>
        /// <response code="400">Quando o corpo da requisição está errado ou Login já existe na base</response>
        /// <response code="401">Quando há problemas na autorização (token JWT inválido ou falta dele)</response>
        /// <response code="500">Quando ocorre um erro não mapeado</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
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
                return BadRequest(new ProblemDetails
                {
                    Status = 400,
                    Title = ex.Message
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ProblemDetails
                {
                    Status = 500,
                    Title = ex.Message
                });
            }
        }
    }
}
