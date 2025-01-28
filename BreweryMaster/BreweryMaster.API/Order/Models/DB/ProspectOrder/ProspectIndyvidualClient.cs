namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectIndyvidualClient : ProspectClient
    {
        [MaxLength(255)]
        public required string Forename { get; set; }
        [MaxLength(255)]
        public required string Surname { get; set; }
    }
}
