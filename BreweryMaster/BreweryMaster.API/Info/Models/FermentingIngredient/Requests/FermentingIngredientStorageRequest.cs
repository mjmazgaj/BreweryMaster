using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientStorageRequest
    {
        [Required]
        [MinIntValidation]
        public int FermentingIngredientUnitId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string? Info { get; set; }
    }
}
