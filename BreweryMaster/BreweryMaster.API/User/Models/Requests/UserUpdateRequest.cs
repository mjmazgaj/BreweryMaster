using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.Users
{
    public class UserUpdateRequest
    {
        [Required]
        [MaxLength(450)]
        public required string Id { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Email { get; set; }
    }
}
