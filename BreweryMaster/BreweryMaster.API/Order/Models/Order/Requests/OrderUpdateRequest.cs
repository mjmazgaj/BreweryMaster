using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? RecipeId { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? Capacity { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? ContainerId { get; set; }

        public DateTime? TargetDate { get; set; }
    }
}
