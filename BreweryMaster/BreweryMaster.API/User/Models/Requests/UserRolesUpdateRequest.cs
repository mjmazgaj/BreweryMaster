namespace BreweryMaster.API.User.Models.Requests
{
    public class UserRolesUpdateRequest
    {
        public required string UserId { get; set; }
        public IEnumerable<string>? RolesId { get; set; }
    }
}
