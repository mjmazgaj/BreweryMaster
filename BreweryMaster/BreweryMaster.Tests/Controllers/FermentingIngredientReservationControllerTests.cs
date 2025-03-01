using BreweryMaster.API.Info.Models;
using BreweryMaster.Tests.Models;
using Moq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class FermentingIngredientReservationControllerTests : BaseTestController
    {
        [Fact]
        public async Task GetFermentingIngredientReservations_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new List<FermentingIngredientReservationResponse>();

            MockFermentingIngredientReservationService.Setup(s => s.GetFermentingIngredientReservations())
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.FermentingIngredientReservation);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
