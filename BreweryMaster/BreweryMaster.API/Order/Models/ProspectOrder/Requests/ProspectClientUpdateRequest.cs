using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectClientUpdateRequest
    {
        [Required]
        [MinIntValidation]
        public int Id { get; set; }

        [MaxLength(256)]
        public string? Forename { get; set; }

        [MaxLength(256)]
        public string? Surname { get; set; }

        [MaxLength(256)]
        public string? CompanyName { get; set; }

        [MaxLength(20)]
        public int? Nip { get; set; }

        [MaxLength(50)]
        [Phone]
        public string? PhoneNumber { get; set; }

        [MaxLength(256)]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
