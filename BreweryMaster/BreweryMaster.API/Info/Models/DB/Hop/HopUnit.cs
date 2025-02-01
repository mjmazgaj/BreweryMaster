using System.Text.Json.Serialization;

namespace BreweryMaster.API.Info.Models
{
    public class HopUnit
    {
        /// <summary>
        /// The Entity id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The hop id in relation. 
        /// </summary>
        public int HopId { get; set; }

        /// <summary>
        /// The hop model representation
        /// </summary>
        public required Hop Hop { get; set; }

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
        ///// The realeted reserved hop
        ///// </summary>
        [JsonIgnore]
        public ICollection<HopOrdered> HopsOrdered { get; set; } = new List<HopOrdered>();

        ///// <summary>
        ///// The realeted ordered hop
        ///// </summary>
        [JsonIgnore]
        public ICollection<HopReserved> HopsReserved { get; set; } = new List<HopReserved>();

        ///// <summary>
        ///// The realeted stored hop
        ///// </summary>
        [JsonIgnore]
        public ICollection<HopStored> HopsStored { get; set; } = new List<HopStored>();
    }
}


