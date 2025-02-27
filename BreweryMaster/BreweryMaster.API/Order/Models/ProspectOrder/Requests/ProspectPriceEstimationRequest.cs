using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectPriceEstimationRequest
    {
        [Required]
        [MinIntValidation]
        public int BeerType { get; set; }

        [Required]
        [MinIntValidation]
        public int ContainerType { get; set; }

        [Required]
        [MinIntValidation]
        public int Capacity { get; set; }
    }
}
