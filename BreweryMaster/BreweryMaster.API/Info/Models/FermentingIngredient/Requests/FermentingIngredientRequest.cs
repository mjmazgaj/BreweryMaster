using BreweryMaster.API.SharedModule.Validators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientRequest
    {
        [Required]
        [MaxLength(256)]
        public required string Name { get; set; }

        [Required]
        [MinIntValidation]
        public int TypeId { get; set; }

        [Precision(5, 2)]
        [Range(0, 100)]
        public decimal? Percentage { get; set; }

        [Range(0, 100)]
        public int? Extraction { get; set; }

        [Range(0, 100)]
        public int? EBC { get; set; }

        public string? Info { get; set; }

        [Required]
        [MinLength(1)]
        [MinIntCollectionValidation]
        public required IEnumerable<int> Units { get; set; }
    }
}
