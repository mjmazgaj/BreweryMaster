using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Recipe.Models.Responses;

namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeDetailsResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? BLGScale { get; set; }
        public int? IBUScale { get; set; }
        public decimal? ABVScale { get; set; }
        public decimal? SRMScale { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int? StyleId { get; set; }
        public string? StyleName { get; set; }
        public int ExpectedBeerVolume { get; set; }
        public int? BoilTime { get; set; }
        public int? EvaporationRate { get; set; }
        public int WortVolume { get; set; }
        public int? BoilLoss { get; set; }
        public decimal? PreBoilGravity { get; set; }
        public int? FermentationLoss { get; set; }
        public int? DryHopLoss { get; set; }
        public int? MashEfficiency { get; set; }
        public decimal? WaterToGrainRatio { get; set; }
        public decimal? MashWaterVolume { get; set; }
        public decimal? TotalMashVolume { get; set; }
        public IEnumerable<RecipeFermentingIngredientResponse>? FermentingIngredients { get; set; }
        public IEnumerable<RecipeHopResponse>? Hops{ get; set; }
        public IEnumerable<RecipeYeastResponse>? Yeast { get; set; }
    }
}
