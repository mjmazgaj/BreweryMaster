namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectIndyvidualClient : ProspectClient
    {
        public required string Forename { get; set; }
        public required string Surname { get; set; }
    }
}
