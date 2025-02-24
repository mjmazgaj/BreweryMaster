namespace BreweryMaster.API.OrderModules.Models
{
    public class ProspectOrderFilterRequest
    {
        public int? ClientId { get; set; }
        public DateTime? ExpectedBefore { get; set; }
        public DateTime? ExpectedAfter { get; set; }
        public int? BeerStyleId { get; set; }
    }
}
