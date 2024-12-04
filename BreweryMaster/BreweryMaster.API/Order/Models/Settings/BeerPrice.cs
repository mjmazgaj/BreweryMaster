using BreweryMaster.API.OrderModule.Enums;

namespace BreweryMaster.API.OrderModule.Models
{
    public class BeerPrice
    {
        public BeerType BeerType { get; set; }
        public decimal EstimatedPrice { get; set; }
    }
}
