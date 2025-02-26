using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models
{
    public class IndividualUserRequest
    {
        [Required]
        [MaxLength(256)]
        public required string Forename { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Surname { get; set; }
    }
}
