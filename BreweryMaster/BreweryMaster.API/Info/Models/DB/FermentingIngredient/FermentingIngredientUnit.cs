using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a fermenting ingredient to unit relation in the database. 
    /// </summary>
    public class FermentingIngredientUnit
    {
        /// <summary>
        /// The Entity id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The fermenting ingredient id in relation. 
        /// </summary>
        public int FermentingIngredientId { get; set; }

        /// <summary>
        /// The fermenting ingredient model representation
        /// </summary>
        public FermentingIngredient FermentingIngredient { get; set; } = null!;

        /// <summary>
        /// The unit id in relation. 
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// The unit model representation
        /// </summary>
        public UnitEntity Unit { get; set; } = null!;

        /// <summary>
        /// The quantity
        /// </summary>
        [Precision(9, 3)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// The removal indicator
        /// </summary>
        public bool IsRemoved { get; set; }

        ///// <summary>
        ///// The realeted reserved fermenting ingredients
        ///// </summary>
        [JsonIgnore]
        public ICollection<FermentingIngredientReserved> FermentingIngredientsReserved { get; set; } = new List<FermentingIngredientReserved>();

        ///// <summary>
        ///// The realeted ordered fermenting ingredients
        ///// </summary>
        [JsonIgnore]
        public ICollection<FermentingIngredientOrdered> FermentingIngredientsOrdered { get; set; } = new List<FermentingIngredientOrdered>();

        ///// <summary>
        ///// The realeted stored fermenting ingredients
        ///// </summary>
        [JsonIgnore]
        public ICollection<FermentingIngredientStored> FermentingIngredientsStored { get; set; } = new List<FermentingIngredientStored>();
    }
}
