using BreweryMaster.API.Info.Models.DB.Yeast;
using System.Text.Json.Serialization;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a fermenting ingredient to unit relation in the database. 
    /// </summary>
    public class YeastUnit
    {
        /// <summary>
        /// The Entity id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The yeast id in relation. 
        /// </summary>
        public int YeastId { get; set; }

        /// <summary>
        /// The yeast model representation
        /// </summary>
        public required Yeast Yeast { get; set; }

        /// <summary>
        /// The unit id in relation. 
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// The unit model representation
        /// </summary>
        public required UnitEntity Unit { get; set; }

        /// <summary>
        /// The removal indicator
        /// </summary>
        public bool IsRemoved { get; set; }

        ///// <summary>
        ///// The realeted reserved yeast
        ///// </summary>
        [JsonIgnore]
        public ICollection<YeastOrdered> YeastOrdered { get; set; } = new List<YeastOrdered>();

        ///// <summary>
        ///// The realeted ordered yeast
        ///// </summary>
        [JsonIgnore]
        public ICollection<YeastReserved> YeastReserved { get; set; } = new List<YeastReserved>();

        ///// <summary>
        ///// The realeted stored yeast
        ///// </summary>
        [JsonIgnore]
        public ICollection<YeastStored> YeastStored { get; set; } = new List<YeastStored>();
    }
}
