using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models
{
    public class IndividualUserRequest
    {
        [Required]
        [MaxLength(255)]
        public required string Forename { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Surname { get; set; }
    }
}
