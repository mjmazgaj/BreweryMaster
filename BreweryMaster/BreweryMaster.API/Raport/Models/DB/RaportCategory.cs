using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.RaportModule.Models
{
    /// <summary>
    /// Represents a category for reports in the system.
    /// </summary>
    public class RaportCategory
    {
        /// <summary>
        /// The id for the report category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the report category.
        /// </summary>
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}
