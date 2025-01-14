using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrderRequest
    {
        [Required]
        [Phone]
        public required string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public int BeerStyleId { get; set; }
        [Required]
        public int ContainerId { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public DateTime TargetDate { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public string? CompanyName { get; set; }
        public int NIP { get; set; }
        [Required]
        public bool IsCompany { get; set; }

    }
}
