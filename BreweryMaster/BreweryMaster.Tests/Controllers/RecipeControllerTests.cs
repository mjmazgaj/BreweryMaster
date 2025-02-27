using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Models.Requests;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.UserModule.Models;
using BreweryMaster.API.Work.Models.Requests;
using BreweryMaster.API.WorkModule.Models;
using BreweryMaster.Tests.Models;
using Microsoft.AspNetCore.WebUtilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class RecipeControllerTests : BaseTestController
    {

        [Theory]
        [InlineData(TestConst.String, 1, 1, HttpStatusCode.OK)]
        [InlineData(TestConst.String257Characters, 1, 1, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, 0, 1, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, 1, 0, HttpStatusCode.BadRequest)]
        public async Task GetRecipes_ShouldReturnProperResponse(string? name, int? typeId, int? beerStyleId, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var queryParams = new Dictionary<string, string?>()
            {
                { "Name", name },
                { "TypeId", typeId.ToString() },
                { "BeerStyleId", beerStyleId.ToString()}
            };

            var response = new List<RecipeResponse>();

            var url = QueryHelpers.AddQueryString(EndpointsConst.Recipe, queryParams);

            MockRecipeService.Setup(s => s.GetRecipes(It.IsAny<RecipeFilterRequest>()))
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(url);

            // Assert
            Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
        }
    }
}
