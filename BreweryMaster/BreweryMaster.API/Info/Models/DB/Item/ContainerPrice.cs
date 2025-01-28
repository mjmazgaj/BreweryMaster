namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a container price in the database.
    /// </summary>
    public class ContainerPrice : ItemPrice
    {
        /// <summary>
        /// The container id
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// The container model representation
        /// </summary>
        public required Container Container { get; set; }
    }
}
