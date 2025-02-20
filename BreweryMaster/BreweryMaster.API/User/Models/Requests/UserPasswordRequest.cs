using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.Requests
{
    public class UserPasswordRequest
    {
        [Required]
        [MaxLength(255)]
        public required string CurrentPassword { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Password { get; set; }

        [Required]
        [MaxLength(255)]
        public required string ConfirmPassword { get; set; }
    }
}
