using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectClientRequest
    {
        [Required]
        public required string Forename { get; set; }
        [Required]
        [Phone]
        public required string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
