using BreweryMaster.API.Info.Models.Item;
using BreweryMaster.API.Recipe.Models.DB;

namespace BreweryMaster.API.OrderModule.Models
{
    /// <summary>
    /// Represents an prospect order in the database.
    /// </summary>
    public class ProspectOrder
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The related prospected client id
        /// </summary>
        public int ProspectClientId { get; set; }

        /// <summary>
        /// The related prospected client model representation
        /// </summary>
        public required ProspectClient ProspectClient { get; set; }

        /// <summary>
        /// The beer style id
        /// </summary>
        public int BeerStyleId { get; set; }

        /// <summary>
        /// The beer style model representation
        /// </summary>
        public required BeerStyleEntity BeerStyle { get; set; }

        /// <summary>
        /// The container id
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// The container model representation
        /// </summary>
        public required Container Container { get; set; }

        /// <summary>
        /// The target date of order realisation
        /// </summary>
        public DateTime TargetDate { get; set; }

        /// <summary>
        /// The capacity
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The date of creation
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The is closed indicator
        /// </summary>
        public bool IsClosed { get; set; } = false;
    }
}
