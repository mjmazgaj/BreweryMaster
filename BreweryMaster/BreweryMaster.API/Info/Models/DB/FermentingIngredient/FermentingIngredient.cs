using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a fermenting ingredient in the database. 
    /// </summary>
    public class FermentingIngredient
    {
        /// <summary>
        /// The Entity id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        [MaxLength(255)]
        public required string Name { get; set; }

        /// <summary>
        /// The type id
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// The type model representation
        /// </summary>
        public FermentingIngredientTypeEntity Type { get; set; } = null!;

        /// <summary>
        /// The percentage
        /// </summary>
        [Precision(5, 2)]
        public decimal? Percentage { get; set; }

        /// <summary>
        /// The extraction
        /// </summary>
        [Range(0, 100)]
        public int? Extraction { get; set; }

        /// <summary>
        /// The ebc unit for measuring beer colour
        /// </summary>
        [Range(0, 100)]
        public int? EBC { get; set; }

        /// <summary>
        /// The removal indicator
        /// </summary>
        public bool IsRemoved { get; set; }

        /// <summary>
        /// The info
        /// </summary>
        public string? Info { get; set; }

        ///// <summary>
        ///// The realeted fermenting ingredient units
        ///// </summary>
        [JsonIgnore]
        public ICollection<FermentingIngredientUnit> FermentingIngredientUnits { get; set; } = new List<FermentingIngredientUnit>();
    }
}
