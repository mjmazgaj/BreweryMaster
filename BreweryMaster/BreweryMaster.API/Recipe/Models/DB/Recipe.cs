using System.Text.Json.Serialization;
using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Recipe.Models.DB
{
    public class Recipe
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [Precision(5, 2)]
        public decimal? BLGScale { get; set; }
        public int? IBUScale { get; set; }
        [Precision(5, 2)]
        public decimal? ABVScale { get; set; }
        [Precision(5, 2)]
        public decimal? SRMScale { get; set; }
        public int? TypeId { get; set; }
        public RecipeTypeEntity? Type { get; set; }
        public int? StyleId { get; set; }
        public BeerStyleEntity? Style { get; set; }
        public int ExpectedBeerVolume { get; set; }
        public int? BoilTime { get; set; }
        public int? EvaporationRate { get; set; }
        public int WortVolume { get; set; }
        public int? BoilLoss { get; set; }
        [Precision(5, 2)]
        public decimal? PreBoilGravity { get; set; }
        public int? FermentationLoss { get; set; }
        public int? DryHopLoss { get; set; }
        public int? MashEfficiency { get; set; }
        [Precision(5, 2)]
        public decimal? WaterToGrainRatio { get; set; }
        [Precision(5, 2)]
        public decimal? MashWaterVolume { get; set; }
        [Precision(5, 2)]
        public decimal? TotalMashVolume { get; set; }
        public string? Info { get; set; }
        public DateTime CreatedOn { get; set; }
        public required string CreatedById { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedById { get; set; }
        public bool IsRemoved { get; set; } = false;
        [JsonIgnore]
        public ICollection<RecipeFermentingIngredient> FermentingIngredients { get; set; } = new List<RecipeFermentingIngredient>();
        [JsonIgnore]
        public ICollection<RecipeHop> RecipeHops { get; set; } = new List<RecipeHop>();
        [JsonIgnore]
        public ICollection<RecipeYeast> RecipeYeasts { get; set; } = new List<RecipeYeast>();
    }
}
