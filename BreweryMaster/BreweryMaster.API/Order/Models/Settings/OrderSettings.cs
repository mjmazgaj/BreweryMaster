namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderSettings
    {
        public int MinimalCapacity { get; set; }
        public IEnumerable<BeerPrice>? BeerPrices { get; set; }
        public IEnumerable<ContainerPrice>? ContainerPrices { get; set; }
    }
}
