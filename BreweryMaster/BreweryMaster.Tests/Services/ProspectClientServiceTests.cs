using BreweryMaster.API.Shared.Helpers;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class ProspectClientServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        public ProspectClientServiceTests()
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
            if (!_dbContext.ProspectClients.Any())
                _dbContext.ProspectClients.AddRange(OrderDataProvider.GetProspectIndyvidualClients());

            _dbContext.SaveChanges();
        }
    }
}
