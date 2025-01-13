using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectPriceEstimationRequest
    {
        [Required]
        public int BeerType { get; set; }
        [Required]
        public int ContainerType { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}
