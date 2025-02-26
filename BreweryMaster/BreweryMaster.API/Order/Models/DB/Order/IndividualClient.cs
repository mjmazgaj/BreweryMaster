using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    /// <summary>
    /// Represents an individual client in the database.
    /// </summary>
    public class IndyvidualClient : Client
    {
        /// <summary>
        /// The forname
        /// </summary>
        [MaxLength(256)]
        public required string Forename { get; set; }

        /// <summary>
        /// The surname
        /// </summary>
        [MaxLength(256)]
        public required string Surname { get; set; }
    }
}
