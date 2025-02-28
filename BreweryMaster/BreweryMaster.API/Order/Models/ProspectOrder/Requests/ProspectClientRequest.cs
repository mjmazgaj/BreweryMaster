using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectClientRequest
    {
        public ProspectClientCompanyRequest? CompanyClient { get; set; }
        public ProspectClientIndividualRequest? IndividualClient { get; set; }

        [Required]
        [MaxLength(50)]
        [Phone]
        public required string PhoneNumber { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public required string Email { get; set; }

        public bool IsCompany { get; set; }
    }
}
