using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.UserModule.Models;

namespace BreweryMaster.API.User.Models.DB
{
    /// <summary>
    /// Represnts an address type to client relations in the database. 
    /// </summary>
    public class ClientAddress
    {
        /// <summary>
        /// The client in relation. 
        /// </summary>
        public int ClientId { get; set; }
        public required Client Client { get; set; }

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
