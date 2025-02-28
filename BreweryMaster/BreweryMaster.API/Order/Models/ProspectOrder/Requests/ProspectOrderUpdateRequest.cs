using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrderUpdateRequest
    {
        [Required]
        [MinIntValidation]
        public int Id { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? BeerStyleId { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? ContainerId { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? Capacity { get; set; }

        public DateTime? TargetDate { get; set; }
    }
}
