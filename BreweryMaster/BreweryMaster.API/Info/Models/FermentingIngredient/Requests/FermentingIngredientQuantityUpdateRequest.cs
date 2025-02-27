using BreweryMaster.API.SharedModule.Validators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientQuantityUpdateRequest
    {
        [Required]
        [MinIntValidation]
        public int Id { get; set; }

        [Required]
        [Precision(9, 3)]
        [Range(0, 1000000)]
        public decimal Quantity { get; set; }

        public string? Info { get; set; }
    }
}
