using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.Users
{
    public class UserUpdateRequest
    {
        [Required]
        [MaxLength(450)]
        public string? Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Email { get; set; }
    }
}
