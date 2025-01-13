using BreweryMaster.API.OrderModule.Enums;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrder
    {
        public int Id { get; set; }
        public int ProspectClientId { get; set; }
        public required ProspectClient ProspectClient { get; set; }
        public DateTime TargetDate { get; set; }
        public int BeerTypeId { get; set; }
    }
}
