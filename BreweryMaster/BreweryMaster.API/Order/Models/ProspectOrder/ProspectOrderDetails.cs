using BreweryMaster.API.Shared.Models;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrderDetails
    {
        public IEnumerable<EntityResponse>? BeerTypes { get; set; }
        public IEnumerable<EntityResponse>? ContainerTypes { get; set; }
    }
}
