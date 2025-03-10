﻿using BreweryMaster.API.Info.Services;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class FermentingIngredientServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        public FermentingIngredientServiceTests()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "FermentingIngredientDb")
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

            if (!_dbContext.FermentingIngredientUnits.Any())
                _dbContext.FermentingIngredientUnits.AddRange(FermentingIngredientDataProvider.GetFermentingIngredientUnit());

            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetFermentingIngredientsAsync_ShouldReturn_AllFermentingIngredients()
        {
            // Arrange
            var service = new FermentingIngredientService(_dbContext);

            // Act
            var result = await service.GetFermentingIngredientsAsync();
            var expectedResult = FermentingIngredientDataProvider.GetFermentingIngredient();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count(), result.Count());
        }
    }
}
