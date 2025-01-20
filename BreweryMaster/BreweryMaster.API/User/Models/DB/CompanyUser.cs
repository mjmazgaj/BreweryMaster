using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.UserModule.Models;

namespace BreweryMaster.API.User.Models.DB
{
    public class CompanyUser : ApplicationUser
    {
        public required string CompanyName { get; set; }
        public required string Nip { get; set; }
        public Address? InvoiceAddress { get; set; }
    }
}
