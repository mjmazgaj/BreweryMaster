using BreweryMaster.API.Info.Enums;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientRequest
    {
        public FermentingIngredientType Type { get; set; }
        [Required]
        public required string Name { get; set; }
        public float Percentage { get; set; }
        public int Extraction { get; set; }
        public int EBC { get; set; }
        public string? Info { get; set; }
    }
}
