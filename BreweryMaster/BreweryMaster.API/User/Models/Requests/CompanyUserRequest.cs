using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models
{
    public class CompanyUserRequest
    {

        [Required]
        [MaxLength(255)]
        public required string CompanyName { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Nip { get; set; }
        public AddressRequest? InvoiceAddress { get; set; }
    }
}
