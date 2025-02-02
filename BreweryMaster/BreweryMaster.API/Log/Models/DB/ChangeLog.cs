using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Log.Models
{
    /// <summary>
    /// Represents a log entry for tracking changes in the database.
    /// </summary>
    public class ChangeLog
    {
        /// <summary>
        /// Entity id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the table where the change occurred.
        /// </summary>
        [MaxLength(255)]
        public required string TableName { get; set; }

        /// <summary>
        /// The type of change (INSERT, UPDATE, DELETE).
        /// </summary>
        [MaxLength(255)]
        public required string ChangeType { get; set; }

        /// <summary>
        /// The JSON representation of the changed data.
        /// </summary>
        public required string ChangedData { get; set; }

        /// <summary>
        /// The timestamp of when the change was logged.
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
