using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.RaportModule.Models
{
    /// <summary>
    /// Represents a report in the system.
    /// </summary>
    public class Raport
    {
        /// <summary>
        /// The id for the report.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title.
        /// </summary>
        [MaxLength(255)]
        public required string Title { get; set; }

        /// <summary>
        /// A summary or description.
        /// </summary>
        public string? Summary { get; set; }

        /// <summary>
        /// The category Id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The category entity reference for the report.
        /// </summary>
        public required RaportCategory Category { get; set; }

        /// <summary>
        /// The identifier of the user who created the report.
        /// </summary>
        [MaxLength(450)]
        public required string CreatedById { get; set; }

        /// <summary>
        /// The timestamp when the report was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
