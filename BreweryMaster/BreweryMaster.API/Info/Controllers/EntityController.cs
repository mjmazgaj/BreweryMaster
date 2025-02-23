using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
using BreweryMaster.API.Shared.Models;
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
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetUnits()
        {
            var units = await _entityService.GetUnitsAsync();
            return Ok(units);
        }

        [HttpGet]
        [Route("Container")]
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetContainers()
        {
            var containers = await _entityService.GetContainers();
            return Ok(containers);
        }
    }
}
