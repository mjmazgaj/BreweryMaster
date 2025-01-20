using BreweryMaster.API.Info.Models.Item;
using BreweryMaster.API.User.Models.Users.DB;

namespace BreweryMaster.API.OrderModule.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required ApplicationUser User { get; set; }
        public required string UserId { get; set; }
        public required Recipe.Models.DB.Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public int Capacity { get; set; }
        public required Container Container { get; set; }
        public int ContainerId { get; set; }
        public DateTime TargetDate { get; set; }
        public decimal Price { get; set; }
    }
}
