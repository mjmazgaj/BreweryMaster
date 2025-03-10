﻿using BreweryMaster.API.User.Models.Users.DB;
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
        [MaxLength(256)]
        public required string TableName { get; set; }

        /// <summary>
        /// The type of change (INSERT, UPDATE, DELETE).
        /// </summary>
        [MaxLength(256)]
        public required string ChangeType { get; set; }

        /// <summary>
        /// The JSON representation of the changed data.
        /// </summary>
        public required string ChangedData { get; set; }

        /// <summary>
        /// The Id of the user how make a change.
        /// </summary>
        [MaxLength(450)]
        public required string ChangedById { get; set; }

        /// <summary>
        /// The timestamp when the change was logged.
        /// </summary>
        public DateTime ChangedOn { get; set; } = DateTime.UtcNow;
    }
}
