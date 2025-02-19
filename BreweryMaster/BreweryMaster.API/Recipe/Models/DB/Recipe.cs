using System.Text.Json.Serialization;
using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Recipe.Models.DB
{
    /// <summary>
    /// Represents a beer recipe in the database.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// The Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the recipe
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The BLG scale
        /// </summary>
        [Precision(5, 2)]
        public decimal? BLGScale { get; set; }

        /// <summary>
        /// The International Bitterness Units
        /// </summary>
        public int? IBUScale { get; set; }

        /// <summary>
        /// The Alcohol By Volume percentage
        /// </summary>
        [Precision(5, 2)]
        public decimal? ABVScale { get; set; }

        /// <summary>
        /// The SRM scale for beer color measurement
        /// </summary>
        [Precision(5, 2)]
        public decimal? SRMScale { get; set; }

        /// <summary>
        /// The type id of the recipe
        /// </summary>
        public int? TypeId { get; set; }

        /// <summary>
        /// The type model representation
        /// </summary>
        public RecipeTypeEntity? Type { get; set; }

        /// <summary>
        /// The style id of the beer
        /// </summary>
        public int? StyleId { get; set; }

        /// <summary>
        /// The style model representation
        /// </summary>
        public BeerStyleEntity? Style { get; set; }

        /// <summary>
        /// The expected beer volume in liters
        /// </summary>
        public int ExpectedBeerVolume { get; set; }

        /// <summary>
        /// The total boil time in minutes
        /// </summary>
        public int? BoilTime { get; set; }

        /// <summary>
        /// The evaporation rate percentage during boiling
        /// </summary>
        public int? EvaporationRate { get; set; }

        /// <summary>
        /// The initial wort volume before fermentation
        /// </summary>
        public int WortVolume { get; set; }

        /// <summary>
        /// The boil loss volume in liters
        /// </summary>
        public int? BoilLoss { get; set; }

        /// <summary>
        /// The pre-boil gravity measurement
        /// </summary>
        [Precision(5, 2)]
        public decimal? PreBoilGravity { get; set; }

        /// <summary>
        /// The estimated fermentation loss in liters
        /// </summary>
        public int? FermentationLoss { get; set; }

        /// <summary>
        /// The estimated loss due to dry hopping
        /// </summary>
        public int? DryHopLoss { get; set; }

        /// <summary>
        /// The mash efficiency percentage
        /// </summary>
        public int? MashEfficiency { get; set; }

        /// <summary>
        /// The water-to-grain ratio during mashing
        /// </summary>
        [Precision(5, 2)]
        public decimal? WaterToGrainRatio { get; set; }

        /// <summary>
        /// The mash water volume in liters
        /// </summary>
        [Precision(5, 2)]
        public decimal? MashWaterVolume { get; set; }

        /// <summary>
        /// The total mash volume in liters
        /// </summary>
        [Precision(5, 2)]
        public decimal? TotalMashVolume { get; set; }

        /// <summary>
        /// The price per expected beer Volume
        /// </summary>
        [Precision(8, 2)]
        public decimal Price { get; set; }

        /// <summary>
        /// Additional recipe information
        /// </summary>
        public string? Info { get; set; }

        /// <summary>
        /// The timestamp when the recipe was created
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The identifier of the user who created the recipe
        /// </summary>
        public required string CreatedById { get; set; }

        /// <summary>
        /// The timestamp of the last modification
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// The identifier of the user who last modified the recipe
        /// </summary>
        public string? ModifiedById { get; set; }

        /// <summary>
        /// Indicates whether the recipe is removed
        /// </summary>
        public bool IsRemoved { get; set; } = false;

        /// <summary>
        /// The collection of fermenting ingredients used in the recipe
        /// </summary>
        [JsonIgnore]
        public ICollection<RecipeFermentingIngredient> FermentingIngredients { get; set; } = new List<RecipeFermentingIngredient>();

        /// <summary>
        /// The collection of hops used in the recipe
        /// </summary>
        [JsonIgnore]
        public ICollection<RecipeHop> Hops { get; set; } = new List<RecipeHop>();

        /// <summary>
        /// The collection of yeasts used in the recipe
        /// </summary>
        [JsonIgnore]
        public ICollection<RecipeYeast> Yeast { get; set; } = new List<RecipeYeast>();
    }
}