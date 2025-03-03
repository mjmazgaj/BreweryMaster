using BreweryMaster.API.SharedModule.Validators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientStorageRequest
    {
        [Required]
        [MinIntValidation]
        public int FermentingIngredientUnitId { get; set; }

        [Required]
        [Precision(9, 3)]
        [Range(0.001, 1000000)]
        public decimal Quantity { get; set; }

        [Required]
        public bool IsReducing { get; set; }

        public string? Info { get; set; }
    }
}
