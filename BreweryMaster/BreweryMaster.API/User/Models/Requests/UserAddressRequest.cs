using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.Requests
{
    public class UserAddressRequest
    {
        [Required]
        [MaxLength(450)]
        public required string UserId { get; set; }

        [Required]
        [MinIntValidation]
        public int AddressId { get; set; }

        [Required]
        [MinIntValidation]
        public int AddressTypeId { get; set; }
    }
}
