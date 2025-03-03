using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.Tests.Models;
using Microsoft.AspNetCore.WebUtilities;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace BreweryMaster.Tests.Controllers
{
    public class OrderControllerTests : BaseTestController
    {
        [Theory]
        [InlineData(TestConst.String, TestConst.Date, TestConst.Date, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String451Characters, TestConst.Date, TestConst.Date, TestConst.String, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, TestConst.Date, TestConst.Date, TestConst.String257Characters, HttpStatusCode.BadRequest)]
        [InlineData(null, TestConst.Date, TestConst.Date, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String, null, TestConst.Date, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String, TestConst.Date, null, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String, TestConst.Date, TestConst.Date, null, HttpStatusCode.OK)]
        public async Task GetOrders_ShouldReturnProperResponse(string? createdBy, string? expectedBefore, string? expectedAfter, string? recipeName, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var queryParams = new Dictionary<string, string?>()
        {
            { "CreatedBy", createdBy },
            { "ExpectedBefore", expectedBefore },
            { "ExpectedAfter", expectedAfter },
            { "RecipeName", recipeName }
        };

            var response = new List<OrderResponse>();

            var url = QueryHelpers.AddQueryString(EndpointsConst.OrderAll, queryParams);

            MockOrderService.Setup(s => s.GetOrders(It.IsAny<OrderFilterRequest>()))
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(url);

            // Assert
            Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
        }

        [Theory]
        [InlineData(1, 1, HttpStatusCode.OK)]
        [InlineData(1, 0, HttpStatusCode.BadRequest)]
        [InlineData(0, 1, HttpStatusCode.BadRequest)]
        [InlineData(null, 1, HttpStatusCode.BadRequest)]
        [InlineData(1, null, HttpStatusCode.BadRequest)]
        public async Task CreateOrderStatusChange_ShouldReturnProperResponse(int? orderId, int? orderStatusId, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var request = new
            {
                OrderId = orderId,
                OrderStatusId = orderStatusId,
            };

            var response = new OrderStatusChangeResponse();

            MockOrderService.Setup(s => s.CreateOrderStatusChange(It.IsAny<OrderStatusChangeRequest>()))
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.PostAsJsonAsync(EndpointsConst.OrderStatus, request);

            // Assert
            Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
        }
    }
}
