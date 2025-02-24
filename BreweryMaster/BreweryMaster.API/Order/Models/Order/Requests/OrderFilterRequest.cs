namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderFilterRequest
    {
        public string? CreatedBy { get; set; }
        public DateTime? ExpectedBefore { get; set; }
        public DateTime? ExpectedAfter { get; set; }
        public string? RecipeName { get; set; }
    }
}
