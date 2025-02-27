using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrderRequest
    {
        [Required]
        [MaxLength(50)]
        [Phone]
        public required string PhoneNumber { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinIntValidation]
        public int BeerStyleId { get; set; }

        [Required]
        [MinIntValidation]
        public int ContainerId { get; set; }

        [Required]
        [MinIntValidation]
        public int Capacity { get; set; }

        [Required]
        public DateTime TargetDate { get; set; }

        [MaxLength(256)]
        public string? Forename { get; set; }

        [MaxLength(256)]
        public string? Surname { get; set; }

        [MaxLength(256)]
        public string? CompanyName { get; set; }

        public int NIP { get; set; }

        [Required]
        public bool IsCompany { get; set; }
    }
}
