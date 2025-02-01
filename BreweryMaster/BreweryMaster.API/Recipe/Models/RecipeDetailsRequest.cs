using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeDetailsRequest
    {
        [Required]
        public required string Name { get; set; }
        public decimal? BLGScale { get; set; }
        public int? IBUScale { get; set; }
        public decimal? ABVScale { get; set; }
        public decimal? SRMScale { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int? StyleId { get; set; }
        public string? StyleName { get; set; }
        [Required]
        public int ExpectedBeerVolume { get; set; }
        public int? BoilTime { get; set; }
        public int? EvaporationRate { get; set; }
        [Required]
        public int WortVolume { get; set; }
        public int? BoilLoss { get; set; }
        public decimal? PreBoilGravity { get; set; }
        public int? FermentationLoss { get; set; }
        public int? DryHopLoss { get; set; }
        public int? MashEfficiency { get; set; }
        public decimal? WaterToGrainRatio { get; set; }
        public decimal? MashWaterVolume { get; set; }
        public decimal? TotalMashVolume { get; set; }
        public Dictionary<int, RecipeQuantityRequest>? FermentingIngredients { get; set; }
        public Dictionary<int, RecipeQuantityRequest>? Hops { get; set; }
        public Dictionary<int, RecipeQuantityRequest>? Yeast { get; set; }
        public Dictionary<int, RecipeQuantityRequest>? Extras { get; set; }
    }
}
