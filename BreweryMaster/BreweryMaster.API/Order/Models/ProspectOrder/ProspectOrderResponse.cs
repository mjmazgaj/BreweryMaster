using BreweryMaster.API.OrderModule.Enums;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrderResponse
    {
        public int Id { get; set; }
        public int ProspectClientId { get; set; }
        public DateOnly TargetDate { get; set; }
        public BeerType OrderId { get; set; }
    }
}
