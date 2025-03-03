using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.OrderModule.Services;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Services;
using BreweryMaster.Tests.Helpers;
using BreweryMaster.Tests.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BreweryMaster.Tests.Services
{
    public class OrderServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Mock<IUserService> _userService;
        public OrderServiceTests()
        {
            _userService = new Mock<IUserService>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "OrderDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!_dbContext.Users.Any())
                _dbContext.Users.AddRange(UserDataProvider.GetUsers());

            if (!_dbContext.Containers.Any())
                _dbContext.Containers.AddRange(ItemDataProvider.GetContainers());

            if (!_dbContext.Recipes.Any())
                _dbContext.Recipes.AddRange(RecipeDataProvider.GetRecpies());

            if (!_dbContext.Orders.Any())
                _dbContext.Orders.AddRange(OrderDataProvider.GetOrders());

            if (!_dbContext.OrderStatuses.Any())
                _dbContext.OrderStatuses.AddRange(EntityDataProvider.GetOrderStatuses());

            if (!_dbContext.OrderStatusChanges.Any())
                _dbContext.OrderStatusChanges.AddRange(OrderDataProvider.GetOrderStatusChanges());

            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineData(TestConst.User1, TestConst.Date, TestConst.Date, TestConst.String)]
        [InlineData(TestConst.User2, TestConst.Date, TestConst.Date, TestConst.String)]
        [InlineData(null, TestConst.Date, TestConst.Date, TestConst.String)]
        [InlineData(TestConst.User1, null, TestConst.Date, TestConst.String)]
        [InlineData(TestConst.User1, TestConst.Date, null, TestConst.String)]
        [InlineData(TestConst.User1, TestConst.Date, TestConst.Date, null)]
        [InlineData(TestConst.User1, null, null, null)]
        [InlineData(null, null, null, null)]
        public async Task GetOrders_ShouldFilter_ByProvidedParameters(string? createdBy, string? expectedBeforeString, string? expectedAfterString, string? recipeName)
        {
            // Arrange
            var service = new OrderService(_dbContext, _userService.Object);

            DateTime? expectedBefore = string.IsNullOrEmpty(expectedBeforeString) ? null : DateTime.Parse(expectedBeforeString);
            DateTime? expectedAfter = string.IsNullOrEmpty(expectedAfterString) ? null : DateTime.Parse(expectedAfterString);

            var request = new OrderFilterRequest
            {
                CreatedBy = createdBy,
                ExpectedBefore = expectedBefore,
                ExpectedAfter = expectedAfter,
                RecipeName = recipeName
            };

            var expectedResult = _dbContext.Orders
                                    .Where(x => !x.IsRemoved)
                                    .Where(x => request.CreatedBy == null || x.CreatedByUserId == request.CreatedBy)
                                    .Where(x => request.ExpectedBefore == null || x.TargetDate >= request.ExpectedBefore)
                                    .Where(x => request.ExpectedAfter == null || x.TargetDate <= request.ExpectedAfter)
                                    .Where(x => request.RecipeName == null || x.Recipe.Name.ToLower().Contains(request.RecipeName.ToLower()))
                                    .ToList();

            // Act
            var result = await service.GetOrders(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count, result.Count());
        }

        [Fact]
        public async Task CreateOrderStatusChange_ShouldAddItem()
        {
            // Arrange
            var service = new OrderService(_dbContext, _userService.Object);


            var request = new OrderStatusChangeRequest
            {
                OrderId = 1,
                OrderStatusId = 1
            };

            // Act
            var result = await service.CreateOrderStatusChange(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.OrderId, request.OrderId);
            Assert.Equal(result.OrderStatusId, request.OrderStatusId);
        }
    }
}
