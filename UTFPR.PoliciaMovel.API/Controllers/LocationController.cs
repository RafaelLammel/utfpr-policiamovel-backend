using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTFPR.PoliciaMovel.Application.Exceptions;
using UTFPR.PoliciaMovel.Application.Locations;

namespace UTFPR.PoliciaMovel.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Cria uma localização vinculada a um usuário
        /// </summary>
        /// <param name="createLocationRequest"></param>
        /// <response code="201">Localização criada com sucesso</response>
        /// <response code="400">Quando o corpo da requisição está errado</response>
        /// <response code="401">Quando há problemas na autorização (token JWT inválido ou falta dele)</response>
        /// <response code="500">Quando ocorre um erro não mepado</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateLocationRequest createLocationRequest)
        {
            try
            {
                await _locationService.SaveAsync(createLocationRequest);
                return Created("", null);
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

        /// <summary>
        /// Atualiza uma localização vinculada a um usuário
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="updateLocationRequest"></param>
        /// <response code="204">Localização atualizada com sucesso</response>
        /// <response code="400">Quando o corpo da requisição está errado</response>
        /// <response code="401">Quando há problemas na autorização (token JWT inválido ou falta dele)</response>
        /// <response code="404">Quando o usuário informado não é encontrado na base</response>
        /// <response code="500">Quando ocorre um erro não mepado</response>
        [HttpPut("{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(string userId, [FromBody] UpdateLocationRequest updateLocationRequest)
        {
            try
            {
                if (userId != User.Identity.Name)
                    return BadRequest();
                
                await _locationService.UpdateAsync(userId, updateLocationRequest);
                return NoContent();
            }
            catch(LocationNotFoundByUserIdException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Status = 404,
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