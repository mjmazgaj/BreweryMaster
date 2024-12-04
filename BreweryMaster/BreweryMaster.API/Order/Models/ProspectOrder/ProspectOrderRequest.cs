using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Order.Models.ProspectOrder
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
        public string? SelectedBeer { get; set; }
        [Required]
        public string? SelectedContainer { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public DateOnly TargetDate { get; set; }
    }
}
