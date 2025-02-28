using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectClientIndividualRequest
    {
        [Required]
        [MaxLength(256)]
        public required string Forename { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Surname { get; set; }
    }
}
