using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrderRequest
    {
        [Required]
        public required ProspectClientRequest Client { get; set; }

        [Required]
        [MinIntValidation]
        public int BeerStyleId { get; set; }

        [Required]
        [MinIntValidation]
        public int ContainerId { get; set; }

        [Required]
        [MinIntValidation]
        public int Capacity { get; set; }

        [Required]
        public DateTime TargetDate { get; set; }
    }
}
