using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.DB
{
    /// <summary>
    /// Resents an address types in the database. 
    /// </summary>
    public class AddressTypeEntity
    {
        /// <summary>
        /// The type address id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The type address name
        /// </summary>
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
