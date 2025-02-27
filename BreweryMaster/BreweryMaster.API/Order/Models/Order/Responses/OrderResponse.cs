namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Recipe { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int ContainerId { get; set; }
        public string Container { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateOnly TargetDate { get; set; }
        public decimal Price { get; set;}
    }
}
