using BreweryMaster.API.OrderModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a reserved hop in the database. 
    /// </summary>
    public class HopReserved : HopQuantity
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
        [Precision(5, 2)]
        public decimal ReservedQuantity { get; set; }

        /// <summary>
        /// The reservation date
        /// </summary>
        public DateTime ReservationDate { get; set; }
    }
}
