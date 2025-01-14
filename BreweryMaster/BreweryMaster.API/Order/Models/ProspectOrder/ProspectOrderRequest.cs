using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrderRequest
    {
        [Required]
        public string? Forename { get; set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public int BeerStyleId { get; set; }
        [Required]
        public int ContainerId { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public DateTime TargetDate { get; set; }
    }
}
