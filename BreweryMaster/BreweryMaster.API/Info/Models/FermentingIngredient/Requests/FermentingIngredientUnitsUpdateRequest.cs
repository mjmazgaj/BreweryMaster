using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientUnitsUpdateRequest
    {
        [Required]
        [MinIntValidation]
        public int Id { get; set; }

        [Required]
        [MinIntCollectionValidation]
        public required List<int> UnitsId { get; set; }
    }
}
