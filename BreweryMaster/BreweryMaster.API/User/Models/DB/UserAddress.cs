using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.UserModule.Models;

namespace BreweryMaster.API.User.Models.DB
{
    /// <summary>
    /// Represents an address to type relations in the database. 
    /// </summary>
    public class UserAddress
    {
        /// <summary>
        /// The user in relation. 
        /// </summary>
        public required string UserId { get; set; }
        public required ApplicationUser User { get; set; }

        /// <summary>
        /// The address in relation. 
        /// </summary>
        public int AddressId { get; set; }
        public required Address Address { get; set; }

        /// <summary>
        /// The address type in relation. 
        /// </summary>
        public int AddressTypeId { get; set; }
        public required AddressTypeEntity AddressType { get; set; }
    }
}
