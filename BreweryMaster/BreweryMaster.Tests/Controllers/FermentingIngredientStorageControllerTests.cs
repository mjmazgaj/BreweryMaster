using BreweryMaster.API.Info.Services;
using BreweryMaster.Tests.Models;
using Moq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class FermentingIngredientStorageControllerTests : BaseTestController
    {

        [Theory]
        [InlineData(-1, HttpStatusCode.BadRequest)]
        [InlineData(0, HttpStatusCode.BadRequest)]
        [InlineData(1, HttpStatusCode.OK)]
        public async Task GetFermentingIngredientStorageById_ShouldReturnProperResponse(int? id, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            MockFermentingIngredientStorageService.Setup(s => s.GetFermentingIngredientStorageById(It.IsAny<int>()))
                .ReturnsAsync(new FermentingIngredientStorageResponse());

            // Act
            var response = await Client.GetAsync($"{EndpointsConst.FermentingIngredientStorage}/{id}");

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }
    }
}
