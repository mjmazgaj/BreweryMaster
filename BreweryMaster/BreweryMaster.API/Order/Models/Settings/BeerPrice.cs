using BreweryMaster.API.Order.Enums;

namespace BreweryMaster.API.Order.Models.Settings
{
    public class BeerPrice
    {
        public BeerType BeerType { get; set; }
        public decimal EstimatedPrice { get; set; }
    }
}
