using BreweryMaster.API.User.Models.Users.DB;

namespace BreweryMaster.API.User.Models.DB
{
    public class IndividualUser : ApplicationUser
    {
        public required string Forename { get; set; }
        public required string Surname { get; set; }
    }
}
