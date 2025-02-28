using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.OrderModule.Services;
using BreweryMaster.API.OrderModules.Models;
using BreweryMaster.API.Shared.Helpers;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Services;
using BreweryMaster.Tests.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BreweryMaster.Tests.Services
{
    public class ProspectOrderServiceTests
    {
        private readonly Mock<IProspectClientService> _prospectClientService;
        private readonly ApplicationDbContext _dbContext;
        public ProspectOrderServiceTests()
        {
            _prospectClientService = new Mock<IProspectClientService>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProspectOrderDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!_dbContext.BeerStyles.Any())
                _dbContext.BeerStyles.AddRange(RecipeDataProvider.GetBeerStyleEntity());

            if (!_dbContext.ProspectClients.Any())
            {
                _dbContext.ProspectClients.AddRange(OrderDataProvider.GetProspectIndyvidualClients());
                _dbContext.ProspectClients.AddRange(OrderDataProvider.GetProspectCompanyClients());
            }

            if (!_dbContext.Containers.Any())
                _dbContext.Containers.AddRange(ItemDataProvider.GetContainers());

            if (!_dbContext.ProspectOrders.Any())
                _dbContext.ProspectOrders.AddRange(OrderDataProvider.GetProspectOrders());

            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineData(1, TestConst.Date, TestConst.Date, 1)]
        [InlineData(null, TestConst.Date, TestConst.Date, 1)]
        [InlineData(1, null, TestConst.Date, 1)]
        [InlineData(1, TestConst.Date, null, 1)]
        [InlineData(1, TestConst.Date, TestConst.Date, null)]
        public async Task GetProspectOrdersAsync_ShouldFilter_ByProvidedParameters(int? clientId, string? expectedBeforeString, string? expectedAfterString, int? beerStyleId)
        {
            // Arrange
            var service = new ProspectOrderService(_dbContext, _prospectClientService.Object);

            DateTime? expectedBefore = string.IsNullOrEmpty(expectedBeforeString) ? null : DateTime.Parse(expectedBeforeString);
            DateTime? expectedAfter = string.IsNullOrEmpty(expectedAfterString) ? null : DateTime.Parse(expectedAfterString);

            var request = new ProspectOrderFilterRequest
            {
                ClientId = clientId,
                ExpectedBefore = expectedBefore,
                ExpectedAfter = expectedAfter,
                BeerStyleId = beerStyleId
            };

            var expectedResult = _dbContext.ProspectOrders
                                    .Where(x => !x.IsRemoved)
                                    .Where(x => request.ClientId == null || x.ProspectClientId == request.ClientId)
                                    .Where(x => request.ExpectedBefore == null || x.TargetDate <= request.ExpectedBefore)
                                    .Where(x => request.ExpectedAfter == null || x.TargetDate >= request.ExpectedAfter)
                                    .Where(x => request.BeerStyleId == null || x.BeerStyleId == request.BeerStyleId)
                                    .ToList();

            // Act
            var result = await service.GetProspectOrdersAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count, result.Count());
        }
    }
}
