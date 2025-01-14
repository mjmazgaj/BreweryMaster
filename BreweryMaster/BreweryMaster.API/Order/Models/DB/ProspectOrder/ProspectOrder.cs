using BreweryMaster.API.Recipe.Models.DB;
using BreweryMaster.API.Shared.Models.DB;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrder
    {
        public int Id { get; set; }
        public int ProspectClientId { get; set; }
        public required ProspectClient ProspectClient { get; set; }
        public int BeerStyleId { get; set; }
        public required BeerStyleEntity BeerStyle { get; set; }
        public int ContainerId { get; set; }
        public required Container Container { get; set; }
        public DateTime TargetDate { get; set; }
        public int Capacity { get; set; }
    }
}
