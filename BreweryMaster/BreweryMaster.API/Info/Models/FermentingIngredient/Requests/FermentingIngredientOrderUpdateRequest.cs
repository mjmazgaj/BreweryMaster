using BreweryMaster.API.SharedModule.Validators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientOrderUpdateRequest
    {
        [MinIntValidation]
        public int? Id { get; set; }

        [Precision(9, 3)]
        [Range(0, 1000000)]
        public decimal? Quantity { get; set; }

        public string? Info { get; set; }

        public DateTime? ExpectedDate { get; set; }
    }
}