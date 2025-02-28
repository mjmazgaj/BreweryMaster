using BreweryMaster.API.OrderModule.Services;
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
            .UseInMemoryDatabase(databaseName: "ProspectClientDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!_dbContext.ProspectClients.Any())
                _dbContext.ProspectClients.AddRange(OrderDataProvider.GetProspectIndyvidualClients());

            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetProspectClientsAsync_ShouldReturn_AllProspectClients()
        {
            // Arrange
            var service = new ProspectClientService(_dbContext);

            // Act
            var result = await service.GetProspectClientsAsync();
            var expectedResult = OrderDataProvider.GetProspectIndyvidualClients();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count(), result.Count());
        }
    }
}
