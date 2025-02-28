using BreweryMaster.API.User.Models;
using BreweryMaster.Tests.Models;
using Moq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class AddressControllerTests : BaseTestController
    {

        [Theory]
        [InlineData(1, HttpStatusCode.OK)]
        [InlineData(0, HttpStatusCode.BadRequest)]
        public async Task GetUserDropDownList_ShouldReturnProperResponse(int? id, HttpStatusCode expectedStatusCode)
        {
            var response = new AddressResponse();

            MockAddressService.Setup(s => s.GetAddressById(It.IsAny<int>()))
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync($"{EndpointsConst.Address}/{id}");

            // Assert
            Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
        }
    }
}
