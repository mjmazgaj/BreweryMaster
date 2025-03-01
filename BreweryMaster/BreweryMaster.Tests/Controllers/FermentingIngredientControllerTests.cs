using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.Tests.Models;
using Moq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class FermentingIngredientControllerTests : BaseTestController
    {

        [Fact]
        public async Task GetFermentingIngredient_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new List<FermentingIngredientResponse>();

            MockFermentingIngredientService.Setup(s => s.GetFermentingIngredientsAsync())
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.FermentingIngredient);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
