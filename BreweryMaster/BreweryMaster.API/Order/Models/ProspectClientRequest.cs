using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Order.Models
{
    public class ProspectClientRequest
    {
        [Required]
        public string? Forename { get; set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
