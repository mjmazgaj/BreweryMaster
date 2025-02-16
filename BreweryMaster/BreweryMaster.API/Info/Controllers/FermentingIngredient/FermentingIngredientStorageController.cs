using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
using BreweryMaster.API.OrderModule.Services;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.Info.Controllers.FermentingIngredient
{
    [Route("api/FermentingIngredient/Storage")]
    [ApiController]
    public class FermentingIngredientStorageController : ControllerBase
    {
        private readonly IFermentingIngredientStorageService _storageService;

        public FermentingIngredientStorageController(IFermentingIngredientStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(FermentingIngredientStorageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FermentingIngredientStorageResponse>> GetFermentingIngredientStorageById([MinIntValidation] int id)
        {
            var storageResponse = await _storageService.GetFermentingIngredientStorageById(id);

            if (storageResponse == null)
                return NotFound();

            return Ok(storageResponse);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FermentingIngredientStorageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FermentingIngredientStorageResponse>> CreateFermentingIngredientStorage(FermentingIngredientStorageRequest request)
        {
            var createdStorage = await _storageService.CreateFermentingIngredientStorage(request);

            if (createdStorage == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetFermentingIngredientStorageById), new { id = createdStorage.Id }, createdStorage);
        }
    }
}
