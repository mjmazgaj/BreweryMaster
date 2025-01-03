using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IEntityService _entityService;

        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        [Route("Unit")]
        [ProducesResponseType(typeof(IEnumerable<UnitEntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UnitEntityResponse>>> GetUnits()
        {
            var units = await _entityService.GetUnitsAsync();
            return Ok(units);
        }
    }
}
