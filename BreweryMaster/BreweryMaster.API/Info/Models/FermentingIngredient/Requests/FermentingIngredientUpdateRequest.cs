using BreweryMaster.API.SharedModule.Validators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientUpdateRequest
    {
        [MinIntValidation]
        public int Id { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }

        [MinIntValidation]
        public int? TypeId { get; set; }

        [Precision(5, 2)]
        [Range(0, 100)]
        public decimal? Percentage { get; set; }

        [Range(0, 100)]
        public int? Extraction { get; set; }

        [Range(0, 100)]
        public int? EBC { get; set; }

        public string? Info { get; set; }
    }
}
