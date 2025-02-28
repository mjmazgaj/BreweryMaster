using BreweryMaster.API.Shared.Helpers;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class ProspectOrderServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        public ProspectOrderServiceTests()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProspectOrderDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!_dbContext.ProspectOrders.Any())
                _dbContext.ProspectOrders.AddRange(OrderDataProvider.GetProspectOrders());

            _dbContext.SaveChanges();
        }
    }
}
