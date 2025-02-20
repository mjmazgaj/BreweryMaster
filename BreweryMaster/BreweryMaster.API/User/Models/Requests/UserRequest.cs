using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models
{
    public class UserRequest
    {
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Password { get; set; }

        [Required]
        [MaxLength(255)]
        public required string ConfirmPassword { get; set; }
    }
}
