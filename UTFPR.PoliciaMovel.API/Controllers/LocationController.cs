using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTFPR.PoliciaMovel.Application.Locations;
using UTFPR.PoliciaMovel.Domain.Entities;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLocationRequest createLocationRequest)
        {
            try
            {
                await _locationService.SaveAsync(createLocationRequest);
                return Created("", null);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(string userId, [FromBody] UpdateLocationRequest updateLocationRequest)
        {
            try
            {
                if (userId != User.Identity.Name)
                {
                    return BadRequest();
                }
                await _locationService.UpdateAsync(userId, updateLocationRequest);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}