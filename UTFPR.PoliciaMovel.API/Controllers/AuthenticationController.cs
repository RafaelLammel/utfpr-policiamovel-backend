using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTFPR.PoliciaMovel.Application.Authentication;
using UTFPR.PoliciaMovel.Application.Exceptions;
using UTFPR.PoliciaMovel.Application.Users;

namespace UTFPR.PoliciaMovel.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        
        public AuthenticationController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        
        /// <summary>
        /// Realiza a autenticação do usuário pelo Login e Senha
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns>Token de Acesso</returns>
        /// <response code="200">Retorna o Token de Acesso</response>
        /// <response code="400">Quando o corpo da requisição está errado</response>
        /// <response code="404">Quando o usuário não é encontrado na base (login ou senha incorretos)</response>
        /// <response code="500">Quando ocorre um erro não mapeado</response>
        [HttpPost]
        [Route("Login")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            try
            {
                LoginResponse user = await _userService.GetByLoginAndPassword(loginRequest);

                string token = _tokenService.GenerateToken(user);
                
                return Ok(new TokenResponse{ AccessToken = token, UserId = user.Id });
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
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