using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
using BreweryMaster.Tests.Models;
using Moq;
using System.Net;
using System.Net.Http.Json;

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

        [Theory]
        [MemberData(nameof(GetTestData))]
        public async Task CreateFermentingIngredientStorage_ShouldReturnProperResponse(
            int? fermentingIngredientUnitId,
            decimal? quantity,
            bool? isReducing,
            string? info,
            HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var request = new
            {
                FermentingIngredientUnitId = fermentingIngredientUnitId,
                Quantity = quantity,
                IsReducing = isReducing,
                Info = info
            };

            MockFermentingIngredientStorageService.Setup(s => s.CreateFermentingIngredientStorage(It.IsAny<FermentingIngredientStorageRequest>()))
                .ReturnsAsync(new FermentingIngredientStorageResponse());

            // Act
            var response = await Client.PostAsJsonAsync(EndpointsConst.FermentingIngredientStorage, request);

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 1, 1.0m, false, TestConst.String, HttpStatusCode.Created };
            yield return new object[] { -2, 0.5m, true, null, HttpStatusCode.BadRequest };
            yield return new object[] { null, null, false, "Test", HttpStatusCode.BadRequest };
        }

    }
}
