﻿using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services.Interfaces;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FermentingIngredientController : ControllerBase
    {
        private readonly IFermentingIngredientService _fermentingIngredientService;

        public FermentingIngredientController(IFermentingIngredientService fermentingIngredientService)
        {
            _fermentingIngredientService = fermentingIngredientService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientResponse>>> GetFermentingIngredient()
        {
            var fermentingIngredients = await _fermentingIngredientService.GetFermentingIngredientsAsync();
            return Ok(fermentingIngredients);
        }

        [HttpGet]
        [Route("Summary")]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientSummaryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientSummaryResponse>>> GetFermentingIngredientSummary()
        {
            var fermentingIngredientsSummary = await _fermentingIngredientService.GetFermentingIngredientSummary();
            return Ok(fermentingIngredientsSummary);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(FermentingIngredientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FermentingIngredientResponse>> GetFermentingIngredientById([MinIntValidation] int id)
        {
            var fermentingIngredient = await _fermentingIngredientService.GetFermentingIngredientByIdAsync(id);

            if (fermentingIngredient == null)
                return NotFound();

            return Ok(fermentingIngredient);
        }

        [HttpGet]
        [Route("Unit")]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientUnitResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientUnitResponse>>> GetFermentingIngredientUnit()
        {
            var fermentingIngredientUnit = await _fermentingIngredientService.GetFermentingIngredientUnitAsync();
            return Ok(fermentingIngredientUnit);
        }

        [HttpGet]
        [Route("Unit/{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientUnitNameResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientUnitNameResponse>>> GetFermentingIngredientUnitNameById(int id)
        {
            var fermentingIngredientsSummary = await _fermentingIngredientService.GetFermentingIngredientUnitNameByIdAsync(id);
            return Ok(fermentingIngredientsSummary);
        }

        [HttpGet]
        [Route("Type")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientTypeEntityResponse>>> GetFermentingIngredientTypes()
        {
            var fermentingIngredientTypes = await _fermentingIngredientService.GetFermentingIngredientTypesAsync();
            return Ok(fermentingIngredientTypes);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FermentingIngredientResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FermentingIngredientResponse>> CreateFermentingIngredient([FromBody] FermentingIngredientRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdFermentingIngredient = await _fermentingIngredientService.CreateFermentingIngredientAsync(request);
            return CreatedAtAction(nameof(GetFermentingIngredientById), new { id = createdFermentingIngredient.Id }, createdFermentingIngredient);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(FermentingIngredientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateFermentingIngredient(int id, [FromBody] FermentingIngredientUpdateRequest request)
        {
            if (!await _fermentingIngredientService.UpdateFermentingIngredientAsync(id, request))
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(FermentingIngredientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteFermentingIngredientById([MinIntValidation] int id)
        {
            if (!await _fermentingIngredientService.DeleteFermentingIngredientByIdAsync(id))
                return NotFound();

            return Ok();
        }
    }
}
