using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.Requests
{
    public class UserRolesUpdateRequest
    {
        [Required]
        [MaxLength(450)]
        public required string UserId { get; set; }

        [Required]
        public IEnumerable<string>? RolesId { get; set; }
    }
}
