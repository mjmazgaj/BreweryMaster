using BreweryMaster.API.Info.Models;
using BreweryMaster.Tests.Models;
using Moq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class FermentingIngredientOrderControllerTests : BaseTestController
    {
        [Fact]
        public async Task GetFermentingIngredientOrders_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new List<FermentingIngredientOrderResponse>();

            MockFermentingIngredientOrderService.Setup(s => s.GetFermentingIngredientOrders())
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.FermentingIngredientOrder);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
