using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.Tests.Models;
using Moq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class ProspectClientControllerTests : BaseTestController
    {

        [Fact]
        public async Task GetProspectClients_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new List<ProspectClientResponse>();

            MockProspectClientService.Setup(s => s.GetProspectClientsAsync())
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.ProspectClient);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
