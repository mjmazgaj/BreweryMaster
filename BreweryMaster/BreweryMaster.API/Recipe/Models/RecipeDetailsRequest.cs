using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeDetailsRequest
    {
        [Required]
        public required string Name { get; set; }
        public float? BLGScale { get; set; }
        public int? IBUScale { get; set; }
        public float? ABVScale { get; set; }
        public float? SRMScale { get; set; }
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
        public float? PreBoilGravity { get; set; }
        public int? FermentationLoss { get; set; }
        public int? DryHopLoss { get; set; }
        public int? MashEfficiency { get; set; }
        public float? WaterToGrainRatio { get; set; }
        public float? MashWaterVolume { get; set; }
        public float? TotalMashVolume { get; set; }
        public IEnumerable<RecipeQuantityRequest>? FermentingIngredientUnits { get; set; }
        public IEnumerable<RecipeQuantityRequest>? Hops { get; set; }
        public IEnumerable<RecipeQuantityRequest>? Yeast { get; set; }
        public IEnumerable<RecipeQuantityRequest>? Extras { get; set; }
    }
}
