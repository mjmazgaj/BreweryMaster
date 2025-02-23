namespace BreweryMaster.API.User.Models.Requests
{
    public class UserFilterRequest
    {
        public string? Email { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public bool? IsCompany { get; set; }
        public string? RoleId { get; set; }
    }
}
