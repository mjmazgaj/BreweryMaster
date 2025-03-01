using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectClientCompanyRequest
    {
        [Required]
        [MaxLength(256)]
        public required string CompanyName { get; set; }

        [Required]
        [MaxLength(12)]
        public required string Nip { get; set; }
    }
}
