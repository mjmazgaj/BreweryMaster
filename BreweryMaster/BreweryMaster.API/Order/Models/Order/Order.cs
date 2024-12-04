using BreweryMaster.API.Order.Enums;

namespace BreweryMaster.API.Order.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RecipeId { get; set; }
        public int Capacity { get; set; }
        public ContainerType ContainerType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public DateOnly TargetDate { get; set; }
        public decimal Price { get; set;}
    }
}
