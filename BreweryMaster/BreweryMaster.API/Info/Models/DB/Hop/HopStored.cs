using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a stored hop in the database. 
    /// </summary>
    public class HopStored : HopQuantity
    {
        /// <summary>
        /// The stored quantity
        /// </summary>
        [Precision(5, 2)]
        public decimal StoredQuantity { get; set; }
    }
}
