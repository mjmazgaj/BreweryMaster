using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    /// <summary>
    /// Represents a company client in the database.
    /// </summary>
    public class CompanyClient : Client
    {
        /// <summary>
        /// The company name
        /// </summary>
        [MaxLength(255)]
        public required string CompanyName { get; set; }

        /// <summary>
        /// The tax identifier of the company
        /// </summary>
        [MaxLength(20)]
        public int Nip { get; set; }
    }
}
