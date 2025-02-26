using BreweryMaster.API.User.Models.Requests;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.Tests.Models;
using Microsoft.AspNetCore.WebUtilities;
using Moq;
using System.Net;

namespace BreweryMaster.Tests.Controllers
{
    public class UserControllerTests : BaseTestController
    {
        [Theory]
        [InlineData(TestConst.String, TestConst.Date, TestConst.Date, true, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String257Characters, TestConst.Date, TestConst.Date, true, TestConst.String, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, TestConst.Date, TestConst.Date, true, TestConst.String451Characters, HttpStatusCode.BadRequest)]
        [InlineData(null, TestConst.Date, TestConst.Date, true, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String, null, TestConst.Date, true, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String, TestConst.Date, null, true, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String, TestConst.Date, TestConst.Date, null, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String, TestConst.Date, TestConst.Date, true, null, HttpStatusCode.OK)]
        public async Task GetUsers_ShouldReturnProperResponse(string? email, string? createdAfter, string? createdBefore, bool? isCompany, string? roleId, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var queryParams = new Dictionary<string, string?>()
        {
            { "Email", email },
            { "CreatedAfter", createdAfter },
            { "CreatedBefore", createdBefore },
            { "IsCompany", isCompany.ToString() },
            { "RoleId", roleId }
        };

            var response = new List<UserResponse>();

            var url = QueryHelpers.AddQueryString(EndpointsConst.User, queryParams);

            MockUserService.Setup(s => s.GetUsers(It.IsAny<UserFilterRequest>()))
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(url);

            // Assert
            Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
        }
    }
}
