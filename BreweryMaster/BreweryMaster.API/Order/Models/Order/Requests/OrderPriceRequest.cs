using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderPriceRequest
    {
        [Required]
        [MinIntValidation]
        public int ContainerId { get; set; }

        [Required]
        [MinIntValidation]
        public int RecipeId { get; set; }

        [Required]
        [MinIntValidation]
        public int Capacity { get; set; }
    }
}