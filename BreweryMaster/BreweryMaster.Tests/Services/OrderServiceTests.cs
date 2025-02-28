using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.Tests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class OrderServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderServiceTests()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            _dbContext.Orders.AddRange(OrderDataProvider.GetOrders());

            _dbContext.SaveChanges();
        }
    }
}
