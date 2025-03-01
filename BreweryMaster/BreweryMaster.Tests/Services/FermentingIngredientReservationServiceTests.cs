using BreweryMaster.API.Info.Services;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class FermentingIngredientReservationServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        public FermentingIngredientReservationServiceTests()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "FermentingIngredientReservationDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!_dbContext.FermentingIngredientTypes.Any())
                _dbContext.FermentingIngredientTypes.AddRange(FermentingIngredientDataProvider.GetFermentingIngredientTypeEntity());

            if (!_dbContext.FermentingIngredients.Any())
                _dbContext.FermentingIngredients.AddRange(FermentingIngredientDataProvider.GetFermentingIngredient());

            if (!_dbContext.UnitTypes.Any())
                _dbContext.UnitTypes.AddRange(EntityDataProvider.GetUnitEntity());

            if (!_dbContext.FermentingIngredientUnits.Any())
                _dbContext.FermentingIngredientUnits.AddRange(FermentingIngredientDataProvider.GetFermentingIngredientUnit());

            if (!_dbContext.FermentingIngredientTypes.Any())
                _dbContext.FermentingIngredientTypes.AddRange(FermentingIngredientDataProvider.GetFermentingIngredientTypeEntity());

            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetFermentingIngredientReservations_ShouldReturn_AllItems()
        {
            // Arrange
            var service = new FermentingIngredientReservationService(_dbContext);

            // Act
            var result = await service.GetFermentingIngredientReservations();
            var expectedResult = FermentingIngredientDataProvider.GetFermentingIngredientReserved();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count(), result.Count());
        }
    }
}
