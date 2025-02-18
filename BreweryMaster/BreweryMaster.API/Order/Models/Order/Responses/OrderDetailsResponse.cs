using BreweryMaster.API.Recipe.Models;

namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderDetailsResponse
    {
        public int Id { get; set; }
        public required RecipeResponse Recipe { get; set; }
        public int Capacity { get; set; }
        public int ContainerId { get; set; }
        public required string Container { get; set; }
        public string? CreatedBy { get; set; }
        public DateOnly CreatedOn { get; set; }
        public DateOnly TargetDate { get; set; }
        public decimal Price { get; set; }
        public int StatusId { get; set; }
        public required string Status { get; set; }
    }
}
