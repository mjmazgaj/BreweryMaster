using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.Tests.Models;
using Moq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class ProspectOrderControllerTests : BaseTestController
    {
        [Fact]
        public async Task GetProspectOrderDetails_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new ProspectOrderDetails();

            MockProspectOrderService.Setup(s => s.GetProspectOrderDetails())
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.ProspectOrder);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
