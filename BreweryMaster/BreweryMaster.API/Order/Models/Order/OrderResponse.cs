namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public int RecipeId { get; set; }
        public int Capacity { get; set; }
        public required string ContainerType { get; set; }
        public int ContainerId { get; set; }
        public DateTime TargetDate { get; set; }
        public decimal Price { get; set;}
    }
}
