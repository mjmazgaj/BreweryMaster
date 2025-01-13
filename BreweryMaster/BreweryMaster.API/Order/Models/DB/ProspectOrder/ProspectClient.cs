namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectClient
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public ICollection<ProspectOrder>? Orders { get; set; }
        public bool IsRemoved { get; set; }
    }
}
