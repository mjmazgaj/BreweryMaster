using BreweryMaster.API.Info.Services;
using BreweryMaster.API.OrderModule.Services;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class EntityServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        public EntityServiceTests()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "EntityDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!_dbContext.UnitTypes.Any())
                _dbContext.UnitTypes.AddRange(EntityDataProvider.GetUnitEntity());

            if (!_dbContext.MaterialTypes.Any())
                _dbContext.MaterialTypes.AddRange(EntityDataProvider.GetMaterialTypes());

            if (!_dbContext.Containers.Any())
                _dbContext.Containers.AddRange(ItemDataProvider.GetContainers());

            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetUnitsAsync_ShouldReturn_AllUnits()
        {
            // Arrange
            var service = new EntityService(_dbContext);

            // Act
            var result = await service.GetUnitsAsync();
            var expectedResult = EntityDataProvider.GetUnitEntity();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count(), result.Count());
        }

        [Fact]
        public async Task GetContainers_ShouldReturn_AllContainers()
        {
            // Arrange
            var service = new EntityService(_dbContext);

            // Act
            var result = await service.GetContainers();
            var expectedResult = ItemDataProvider.GetContainers();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count(), result.Count());
        }
    }
}
