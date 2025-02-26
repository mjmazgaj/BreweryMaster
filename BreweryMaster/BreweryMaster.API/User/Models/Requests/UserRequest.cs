using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models
{
    public class UserRequest
    {
        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Password { get; set; }

        [Required]
        [MaxLength(256)]
        public required string ConfirmPassword { get; set; }
    }
}
