using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientFilterRequest
    {
        [MinIntValidation(isNullAllowed: true)]
        public int? TypeId { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? UnitId { get; set; }
    }
}
