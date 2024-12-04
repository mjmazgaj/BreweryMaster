using BreweryMaster.API.Order.Enums;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Order.Models.Order
{
    public class OrderRequest
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public ContainerType ContainerType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        [Required]
        public DateOnly TargetDate { get; set; }
    }
}
