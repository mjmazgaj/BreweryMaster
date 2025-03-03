using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models
{
    public class AddressTypeRequest : AddressRequest
    {
        [Required]
        [MaxLength(450)]
        public required string UserId { get; set; }

        [Required]
        [MinIntValidation]
        public int TypeId { get; set; }
    }
}
