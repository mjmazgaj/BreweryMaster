using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a hop in the database. 
    /// </summary>
    public class Hop
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
        /// The alpha acids
        /// </summary>
        [Precision(5, 2)]
        public decimal AlphaAcids { get; set; }
    }
}
