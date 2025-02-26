using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.UserModule.Models
{
    /// <summary>
    /// Represents an address stored in the database. 
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Street
        /// </summary>
        [MaxLength(256)]
        public string? Street { get; set; }

        /// <summary>
        /// The house number
        /// </summary>
        [MaxLength(10)]
        public required string HouseNumber { get; set; }

        /// <summary>
        /// The apartment number
        /// </summary>
        [MaxLength(10)]
        public string? ApartamentNumber { get; set; }

        /// <summary>
        /// The postal code
        /// </summary>
        [MaxLength(6)]
        public required string PostalCode { get; set; }

        /// <summary>
        /// The City
        /// </summary>
        [MaxLength(256)]
        public required string City { get; set; }

        /// <summary>
        /// The Commune
        /// </summary>
        [MaxLength(256)]
        public required string Commune { get; set; }

        /// <summary>
        /// The Region
        /// </summary>
        [MaxLength(256)]
        public required string Region { get; set; }

        /// <summary>
        /// The Country
        /// </summary>
        [MaxLength(256)]
        public required string Country { get; set; }
    }
}
