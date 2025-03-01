using BreweryMaster.API.Info.Services;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class FermentingIngredientStorageServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        public FermentingIngredientStorageServiceTests()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "FermentingIngredientStorageDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!_dbContext.FermentingIngredients.Any())
                _dbContext.FermentingIngredients.AddRange(FermentingIngredientDataProvider.GetFermentingIngredient());

            if (!_dbContext.FermentingIngredientTypes.Any())
                _dbContext.FermentingIngredientTypes.AddRange(FermentingIngredientDataProvider.GetFermentingIngredientTypeEntity());

            if (!_dbContext.FermentingIngredientsStored.Any())
                _dbContext.FermentingIngredientsStored.AddRange(FermentingIngredientDataProvider.GetFermentingIngredientStored());

            if (!_dbContext.FermentingIngredientUnits.Any())
                _dbContext.FermentingIngredientUnits.AddRange(FermentingIngredientDataProvider.GetFermentingIngredientUnit());

            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetFermentingIngredientStorageById_ShouldReturn_CorrectItem()
        {
            // Arrange
            var fermentingIngredienntId = 7;
            var service = new FermentingIngredientStorageService(_dbContext);

            var expectedResult = FermentingIngredientDataProvider.GetFermentingIngredientStored()
                                        .Where(x => !x.IsRemoved)
                                        .FirstOrDefault(x => x.Id == fermentingIngredienntId);
            // Act
            var result = await service.GetFermentingIngredientStorageById(fermentingIngredienntId);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(expectedResult);
            Assert.Equal(expectedResult.Id, result.Id);
        }
    }
}
