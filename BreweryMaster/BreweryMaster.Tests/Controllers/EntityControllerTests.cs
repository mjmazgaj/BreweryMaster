using BreweryMaster.API.Shared.Models;
using BreweryMaster.Tests.Models;
using Moq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class EntityControllerTests : BaseTestController
    {

        [Fact]
        public async Task GetUnitsAsync_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new List<EntityResponse>();

            MockEntityService.Setup(s => s.GetUnitsAsync())
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.EntityUnit);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task GetContainers_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new List<EntityResponse>();

            MockEntityService.Setup(s => s.GetContainers())
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.EntityContainer);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
