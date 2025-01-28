namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectCompanyClient : ProspectClient
    {
        [MaxLength(255)]
        public required string CompanyName { get; set; }
        [MaxLength(20)]
        public int Nip { get; set; }
    }
}
