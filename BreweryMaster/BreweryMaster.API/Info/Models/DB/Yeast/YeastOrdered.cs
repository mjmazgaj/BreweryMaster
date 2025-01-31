using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models.DB.Yeast
{
    /// <summary>
    /// Represents a ordered yeast in the database.
    /// </summary>
    public class YeastOrdered : YeastQuantity
    {
        /// <summary>
        /// The ordered quantity
        /// </summary>
        [Precision(10, 3)]
        public decimal OrderedQuantity { get; set; }

        /// <summary>
        /// The ordered date
        /// </summary>
        public DateTime OrderedDate { get; set; }

        /// <summary>
        /// The expected date
        /// </summary>
        public DateTime? ExpectedDate { get; set; }
    }
}
