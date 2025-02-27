using BreweryMaster.API.Recipe.Models;

namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderDetailsResponse
    {
        public int Id { get; set; }
        public RecipeResponse Recipe { get; set; } = null!;
        public int Capacity { get; set; }
        public int ContainerId { get; set; }
        public string Container { get; set; } = string.Empty;
        public string? CreatedBy { get; set; }
        public DateOnly CreatedOn { get; set; }
        public DateOnly TargetDate { get; set; }
        public decimal Price { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; } = string.Empty;
        public IEnumerable<OrderStatusChangeResponse>? StatusChanges { get; set; }
    }
}
