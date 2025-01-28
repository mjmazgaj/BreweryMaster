using BreweryMaster.API.Info.Models;
using BreweryMaster.API.User.Models.Users.DB;
using Microsoft.EntityFrameworkCore;

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
        [Precision(18, 2)]
        public decimal Price { get; set; }
    }
}
