using BreweryMaster.API.Info.Services;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class FermentingIngredientOrderServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        public FermentingIngredientOrderServiceTests()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "FermentingIngredientOrderDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

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

            if (!_dbContext.FermentingIngredientsOrdered.Any())
                _dbContext.FermentingIngredientsOrdered.AddRange(FermentingIngredientDataProvider.GetFermentingIngredientOrdered());

            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetFermentingIngredientsAsync_ShouldReturn_AllFermentingIngredients()
        {
            // Arrange
            var service = new FermentingIngredientOrderService(_dbContext);

            // Act
            var result = await service.GetFermentingIngredientOrders();
            var expectedResult = FermentingIngredientDataProvider.GetFermentingIngredientOrdered();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count(), result.Count());
        }
    }
}
