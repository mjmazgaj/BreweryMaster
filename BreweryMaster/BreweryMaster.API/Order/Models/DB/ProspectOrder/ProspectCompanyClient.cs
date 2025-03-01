using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    /// <summary>
    /// Represents an prospect company client in the database.
    /// </summary>
    public class ProspectCompanyClient : ProspectClient
    {
        /// <summary>
        /// The company name
        /// </summary>
        [MaxLength(256)]
        public required string CompanyName { get; set; }

        /// <summary>
        /// The tax identifier of the company
        /// </summary>
        [MaxLength(20)]
        public required string Nip { get; set; }
    }
}
