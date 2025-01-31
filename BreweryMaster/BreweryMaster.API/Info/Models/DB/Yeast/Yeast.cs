using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a yeast in the database. 
    /// </summary>
    public class Yeast
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
        public required YeastType Type { get; set; }

        /// <summary>
        /// The form id
        /// </summary>
        public int FormId { get; set; }

        /// <summary>
        /// The form model representation
        /// </summary>
        public required YeastForm Form { get; set; }

        /// <summary>
        /// The producer
        /// </summary>
        [MaxLength(255)]
        public string? Producer { get; set; }

        /// <summary>
        /// The removal indicator
        /// </summary>
        public bool IsRemoved { get; set; }

        /// <summary>
        /// The info
        /// </summary>
        public string? Info { get; set; }
    }
}
