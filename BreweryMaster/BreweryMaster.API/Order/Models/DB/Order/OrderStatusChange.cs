using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.OrderModule.Models
{
    /// <summary>
    /// Represents a order status change in the database.
    /// </summary>
    public class OrderStatusChange
    {
        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The order id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The order model representation
        /// </summary>
        public required Order Order { get; set; }

        /// <summary>
        /// The new order status id
        /// </summary>
        public int OrderStatusId { get; set; }

        /// <summary>
        /// The new order status model representation
        /// </summary>
        public required OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// The date when order status was changed
        /// </summary>
        public DateTime ChangedOn { get; set; }
    }
}
