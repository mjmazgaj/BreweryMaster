using BreweryMaster.API.OrderModule.Enums;

namespace BreweryMaster.API.OrderModule.Models
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
