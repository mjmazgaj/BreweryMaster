using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Recipe.Models.Requests
{
    public class RecipeFilterRequest
    {
        [MaxLength(256)]
        public string? Name { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? TypeId { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? BeerStyleId { get; set; }
    }
}
