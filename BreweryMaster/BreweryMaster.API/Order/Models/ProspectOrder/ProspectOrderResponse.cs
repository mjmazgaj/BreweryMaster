namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectOrderResponse
    {
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BeerStyle { get; set; }
        public int BeerStyleId { get; set; }
        public string? Container { get; set; }
        public int ContainerTypeId { get; set; }
        public int Capacity { get; set; }
        public DateOnly TargetDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
