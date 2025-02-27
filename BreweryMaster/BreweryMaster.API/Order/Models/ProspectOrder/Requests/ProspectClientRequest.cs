using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectClientRequest
    {
        [Required]
        [MaxLength(256)]
        public required string Forename { get; set; }

        [Required]
        [MaxLength(50)]
        [Phone]
        public required string PhoneNumber { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
