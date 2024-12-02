namespace BreweryMaster.API.Order.Models.ProspectOrder
{
    public class ProspectOrderDetails
    {
        public IEnumerable<string> BeerTypes { get; set; }
        public IEnumerable<string> ContainerTypes { get; set; }
    }
}
