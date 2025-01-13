namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectCompanyClient : ProspectClient
    {
        public required string CompanyName { get; set; }
        public int Nip { get; set; }
    }
}
