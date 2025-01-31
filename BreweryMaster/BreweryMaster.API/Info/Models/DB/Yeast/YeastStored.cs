using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a stored yeast in the database. 
    /// </summary>
    public class YeastStored : YeastQuantity
    {
        /// <summary>
        /// The stored quantity
        /// </summary>
        [Precision(5, 2)]
        public decimal StoredQuantity { get; set; }
    }
}
