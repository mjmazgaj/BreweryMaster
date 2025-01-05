namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrderDetails
    {
        public IEnumerable<string>? BeerTypes { get; set; }
        public IEnumerable<string>? ContainerTypes { get; set; }
    }
}
