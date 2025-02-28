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
        [MaxLength(20)]
        [MinIntValidation]
        public int Nip { get; set; }
    }
}
