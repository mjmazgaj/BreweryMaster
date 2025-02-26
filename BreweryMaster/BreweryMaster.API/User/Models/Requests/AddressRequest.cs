using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models
{
    public class AddressRequest
    {
        public string? Street { get; set; }

        [Required]
        [MaxLength(10)]
        public required string HouseNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public string? ApartamentNumber { get; set; }

        [Required]
        [MaxLength(6)]
        public required string PostalCode { get; set; }

        [Required]
        [MaxLength(256)]
        public required string City { get; set; }

        [Required]
        [MaxLength(256)] 
        public required string Commune { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Region { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Country { get; set; }
    }
}
