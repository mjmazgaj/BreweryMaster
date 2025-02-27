using BreweryMaster.API.SharedModule.Validators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeRequest
    {
        [Required]
        [MaxLength(256)]
        public required string Name { get; set; }

        [Range(0, 100)]
        [Precision(5, 2)]
        public decimal? BLGScale { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? IBUScale { get; set; }

        [Range(0, 100)]
        [Precision(5, 2)]
        public decimal? ABVScale { get; set; }

        [Range(0, 100)]
        [Precision(5, 2)]
        public decimal? SRMScale { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? TypeId { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? StyleId { get; set; }

        [Required]
        [MinIntValidation]
        public int ExpectedBeerVolume { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? BoilTime { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? EvaporationRate { get; set; }

        [Required]
        public int WortVolume { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? BoilLoss { get; set; }

        [Range(0, 100)]
        [Precision(5, 2)]
        public decimal? PreBoilGravity { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? FermentationLoss { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? DryHopLoss { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? MashEfficiency { get; set; }

        [Range(0, 100)]
        [Precision(5, 2)]
        public decimal? WaterToGrainRatio { get; set; }

        [Range(0, 100)]
        [Precision(5, 2)]
        public decimal? MashWaterVolume { get; set; }

        [Range(0, 100)]
        [Precision(5, 2)]
        public decimal? TotalMashVolume { get; set; }

        [Required]
        [Range(0, 1000000)]
        [Precision(8, 2)]
        public decimal Price { get; set; }

        public string? Info { get; set; }

        public Dictionary<int, RecipeQuantityRequest>? FermentingIngredients { get; set; }

        public Dictionary<int, RecipeQuantityRequest>? Hops { get; set; }

        public Dictionary<int, RecipeQuantityRequest>? Yeast { get; set; }

        public Dictionary<int, RecipeQuantityRequest>? Extras { get; set; }
    }
}
