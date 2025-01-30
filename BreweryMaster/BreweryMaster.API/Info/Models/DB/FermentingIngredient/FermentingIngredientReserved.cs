using BreweryMaster.API.OrderModule.Models;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a reserved fermenting ingredient in the database. 
    /// </summary>
    public class FermentingIngredientReserved : FermentingIngredientQuantity
    {
        /// <summary>
        /// The reserved quantity
        /// </summary>
        public float ReservedQuantity { get; set; }

        /// <summary>
        /// The reservation date
        /// </summary>
        public DateTime ReservationDate { get; set; }
    }
}
