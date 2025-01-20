using BreweryMaster.API.OrderModule.Models;

namespace BreweryMaster.API.Shared.Helpers
{
    public static class OrderDataProvider
    {
        public static IEnumerable<Order> GetOrders()
        {
            return new List<Order>
            {
                new()
                {
                    Id = 1,
                    UserId = "880685e3-e9a9-43b0-a5e5-905d590634c5",
                    User = null!,
                    Capacity = 10,
                    ContainerId = 1,
                    Container = null!,
                    Price = 10,
                    RecipeId = 1,
                    Recipe = null!,
                    TargetDate = DateTime.Now,
                },
                new()
                {
                    Id = 2,
                    UserId = "f31c50a7-431c-4358-8fdc-bfa083cfacb7",
                    User = null!,
                    Capacity = 12310,
                    ContainerId = 1,
                    Container = null!,
                    Price = 11110,
                    RecipeId = 1,
                    Recipe = null!,
                    TargetDate = DateTime.Now,
                },
                new()
                {
                    Id = 3,
                    UserId = "880685e3-e9a9-43b0-a5e5-905d590634c5",
                    User = null!,
                    Capacity = 12,
                    ContainerId = 2,
                    Container = null!,
                    Price = 23,
                    RecipeId = 2,
                    Recipe = null!,
                    TargetDate = DateTime.Now,
                },
            };
        }
    }
}
