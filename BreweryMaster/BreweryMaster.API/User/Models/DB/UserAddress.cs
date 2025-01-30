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
        /// The user id in relation. 
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// The user model representation
        /// </summary>
        public required ApplicationUser User { get; set; }

        /// <summary>
        /// The address in relation. 
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// The address model representation
        /// </summary>
        public required Address Address { get; set; }

        /// <summary>
        /// The address type in relation. 
        /// </summary>
        public int AddressTypeId { get; set; }

        /// <summary>
        /// The address type model representation
        /// </summary>
        public required AddressTypeEntity AddressType { get; set; }
    }
}
