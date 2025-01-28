using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a container  in the database.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The container name
        /// </summary>
        [MaxLength(255)]
        public required string ContainerName { get; set; }

        /// <summary>
        /// The material
        /// </summary>
        [MaxLength(255)]
        public string? Material { get; set; }

        /// <summary>
        /// The capacity
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The unit id
        /// </summary>
        public int UnitEntityId { get; set; }

        /// <summary>
        /// The unit model representation
        /// </summary>
        public required UnitEntity UnitEntity { get; set; }
    }
}
