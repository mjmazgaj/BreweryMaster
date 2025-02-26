using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a material in the database.
    /// </summary>
    public class MaterialType
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        [MaxLength(256)]
        public required string Name { get; set; }
    }
}
