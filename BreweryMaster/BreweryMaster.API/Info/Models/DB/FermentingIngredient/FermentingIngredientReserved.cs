using BreweryMaster.API.OrderModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a reserved fermenting ingredient in the database. 
    /// </summary>
    public class FermentingIngredientReserved : FermentingIngredientQuantity
    {
        /// <summary>
        /// The order id
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// The order model representation
        /// </summary>
        public Order? Order { get; set; }

        /// <summary>
        /// The reserved quantity
        /// </summary>
        public int ReservedQuantity { get; set; }

        /// <summary>
        /// The reservation date
        /// </summary>
        public DateTime ReservationDate { get; set; }

        /// <summary>
        /// The completion indicator
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
