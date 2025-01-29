using BreweryMaster.API.Info.Models;
using BreweryMaster.API.User.Models.Users.DB;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BreweryMaster.API.OrderModule.Models
{
    /// <summary>
    /// Represents an order in the database.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The client for whom the order is being processed.
        /// </summary>
        public int? ClientId { get; set; }

        /// <summary>
        /// The client model representation.
        /// </summary>
        public Client? Client { get; set; }

        /// <summary>
        /// The related recipe id
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        /// The related recipe model representation
        /// </summary>
        public required Recipe.Models.DB.Recipe Recipe { get; set; }

        /// <summary>
        /// The capacity
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The related container id
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// The related container model representation
        /// </summary>
        public required Container Container { get; set; }

        /// <summary>
        /// The expected completion date
        /// </summary>
        public DateTime TargetDate { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        [Precision(18, 2)]
        public decimal Price { get; set; }

        /// <summary>
        /// The creation date
        /// </summary>
        public required DateTime CreatedOn { get; set; }

        /// <summary>
        /// The creator user id
        /// </summary>
        [MaxLength(450)]
        public required string CreatedByUserId { get; set; }

        /// <summary>
        /// The creator user model representation
        /// </summary>
        public required ApplicationUser CreatedByUser { get; set; }

        /// <summary>
        /// The modification date
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// The related list order status models
        /// </summary>
        [JsonIgnore]
        public ICollection<OrderStatusChange>? OrderStatusChanges { get; set; }

        /// <summary>
        /// The removal indicator
        /// </summary>
        public bool IsRemoved { get; set; }
    }
}
