namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public string? User { get; set; }
        public int RecipeId { get; set; }
        public required string Recipe { get; set; }
        public int Capacity { get; set; }
        public int ContainerId { get; set; }
        public required string Container { get; set; }
        public DateTime TargetDate { get; set; }
        public decimal Price { get; set;}
    }
}
