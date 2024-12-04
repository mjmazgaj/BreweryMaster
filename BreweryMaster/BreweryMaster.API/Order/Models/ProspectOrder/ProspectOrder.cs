using BreweryMaster.API.Order.Enums;

namespace BreweryMaster.API.Order.Models.ProspectOrder
{
    public class ProspectOrder
    {
        public int Id { get; set; }
        public int ProspectClientId { get; set; }
        public DateOnly TargetDate { get; set; }
        public BeerType OrderId { get; set; }
    }
}
