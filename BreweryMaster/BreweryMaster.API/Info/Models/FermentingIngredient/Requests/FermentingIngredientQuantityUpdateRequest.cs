using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientQuantityUpdateRequest
    {
        [Required]
        [MinIntValidation]
        public int Id { get; set; }

        [Required]
        [MinIntValidation]
        public int Quantity { get; set; }

        public string? Info { get; set; }
    }
}
