using BreweryMaster.API.Recipe.Models.DB;
using BreweryMaster.API.Recipe.Models.Requests;
using BreweryMaster.API.Recipe.Services;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.Tests.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class RecipeServiceTests
    {
        private readonly ApplicationDbContext _dbContext;

        public RecipeServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "RecipeDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (_dbContext.Recipes.Any())
                return;

            var recipe = new Recipe
            {
                Name = TestConst.String,
                BLGScale = 12.5m,
                IBUScale = 35,
                ABVScale = 5.2m,
                SRMScale = 10.5m,
                TypeId = 1,
                StyleId = 1,
                ExpectedBeerVolume = 20,
                BoilTime = 60,
                EvaporationRate = 5,
                WortVolume = 25,
                BoilLoss = 2,
                PreBoilGravity = 10.8m,
                FermentationLoss = 3,
                DryHopLoss = 1,
                MashEfficiency = 75,
                WaterToGrainRatio = 3.2m,
                MashWaterVolume = 15.5m,
                TotalMashVolume = 20.3m,
                Price = 150.75m,
                Info = TestConst.String,
                CreatedById = TestConst.String,
                CreatedOn = DateTime.Now,
            };

            var recipe2 = new Recipe
            {
                Name = TestConst.String2,
                BLGScale = 14.2m,
                IBUScale = 40,
                ABVScale = 6.5m,
                SRMScale = 15.8m,
                TypeId = 2,
                StyleId = 2,
                ExpectedBeerVolume = 25,
                BoilTime = 75,
                EvaporationRate = 6,
                WortVolume = 30,
                BoilLoss = 3,
                PreBoilGravity = 12.3m,
                FermentationLoss = 4,
                DryHopLoss = 2,
                MashEfficiency = 80,
                WaterToGrainRatio = 3.5m,
                MashWaterVolume = 17.8m,
                TotalMashVolume = 22.1m,
                Price = 200.50m,
                Info = TestConst.String,
                CreatedById = TestConst.String,
                CreatedOn = DateTime.Now,
            };


            _dbContext.Recipes.AddRange(recipe, recipe2);

            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineData(TestConst.String, 1, 1)]
        [InlineData(TestConst.String, null, 1)]
        [InlineData(null, 1, 1)]
        [InlineData(TestConst.String, 1, null)]
        public async Task GetRecipes_ShouldFilter_ByProvidedParameters(string? name, int? typeId, int? beerStyleId)
        {
            // Arrange
            var service = new RecpieService(_dbContext);

            var request = new RecipeFilterRequest
            {
                Name = name,
                TypeId = typeId,
                BeerStyleId = beerStyleId,
            };

            var expectedResult = _dbContext.Recipes
                                    .Where(x => !x.IsRemoved)
                                    .Where(x => request.TypeId == null || x.TypeId == request.TypeId)
                                    .Where(x => request.BeerStyleId == null || x.StyleId == request.BeerStyleId)
                                    .Where(x => request.Name == null || x.Name.ToLower().Contains(request.Name.ToLower()))
                                    .ToList();
            // Act
            var result = await service.GetRecipes(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count, result.Count());
        }
    }
}
