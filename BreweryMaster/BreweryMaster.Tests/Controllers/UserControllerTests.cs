using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.User.Models.Requests;
using BreweryMaster.API.User.Models.Responses;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.Tests.Models;
using Microsoft.AspNetCore.WebUtilities;
using Moq;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;

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

        [Fact]
        public async Task GetUserDropDownList_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new List<EntityStringIdResponse>();

            MockUserService.Setup(s => s.GetRolesDropDownList())
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.UserDropDown);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Theory]
        [InlineData(TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String451Characters, HttpStatusCode.BadRequest)]
        public async Task GetUserById_ShouldReturnProperResponse(string? id, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var response = new UserDetailsResponse() { Email = "", Id = "" };


            MockUserService.Setup(s => s.GetUserById(It.IsAny<string>()))
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync($"{EndpointsConst.User}/${id}");

            // Assert
            Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
        }

        [Theory]
        [InlineData(TestConst.String, TestConst.Email1, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String451Characters, TestConst.Email1, TestConst.String, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, TestConst.String257Characters, TestConst.String, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, TestConst.Email1, TestConst.String257Characters, HttpStatusCode.BadRequest)]
        public async Task Update_ShouldReturnProperResponse(string? id, string? email, string? userId, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var request = new
            {
                Id = id,
                Email = email
            };
            var response = new UserResponse();

            MockUserService.Setup(s => s.UpdateUser(It.IsAny<UserUpdateRequest>(), It.IsAny<string>()))
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.PatchAsJsonAsync($"{EndpointsConst.User}/{userId}", request);

            // Assert
            Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
        }
        [Theory]
        [InlineData(TestConst.String, TestConst.String, TestConst.String, HttpStatusCode.OK)]
        [InlineData(TestConst.String, TestConst.String257Characters, TestConst.String, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, TestConst.String, TestConst.String257Characters, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, TestConst.String, TestConst.String2, HttpStatusCode.BadRequest)]
        public async Task UpdatePassword_ShouldReturnProperResponse(string currentPassword, string password, string confirmPassword, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var request = new UserPasswordRequest
            {
                CurrentPassword = currentPassword,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            MockUserService.Setup(s => s.UpdatePassword(It.IsAny<UserPasswordRequest>(), It.IsAny<ClaimsPrincipal>()))
                .ReturnsAsync(true);

            // Act
            var httpResponse = await Client.PatchAsJsonAsync(EndpointsConst.UserPassword, request);

            // Assert
            Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
        }

        [Theory]
        [InlineData(TestConst.String, new string[] { TestConst.String }, HttpStatusCode.OK)]
        [InlineData(TestConst.String451Characters, new string[] { TestConst.String }, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, new string[] { }, HttpStatusCode.BadRequest)]
        [InlineData(TestConst.String, null, HttpStatusCode.BadRequest)]
        public async Task UpdateUserRoles_ShouldReturnProperResponse(string userId, IEnumerable<string> rolesId, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var request = new UserRolesUpdateRequest
            {
                UserId = userId,
                RolesId = rolesId
            };

            MockUserService.Setup(s => s.UpdateUserRoles(It.IsAny<UserRolesUpdateRequest>()))
                .ReturnsAsync(rolesId != null && rolesId.Any());

            // Act
            var httpResponse = await Client.PatchAsJsonAsync($"{EndpointsConst.UserRoles}/{userId}", request);

            // Assert
            Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
        }

        [Fact]
        public async Task GetInfo_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new UserResponse();

            MockUserService.Setup(s => s.GetCurrentUser(It.IsAny<ClaimsPrincipal>()))
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.UserInfo);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task GetUserDetails_ShouldReturnProperResponse()
        {
            // Arrange
            var response = new UserDetailsResponse();

            MockUserService.Setup(s => s.GetCurrentUserDetails(It.IsAny<ClaimsPrincipal>()))
                .ReturnsAsync(response);

            // Act
            var httpResponse = await Client.GetAsync(EndpointsConst.UserDetails);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task AddTestUsers_ShouldReturnProperResponse()
        {
            // Arrange
            MockUserService.Setup(s => s.CreateTestUsers())
                .ReturnsAsync(true);

            // Act
            var httpResponse = await Client.PostAsync(EndpointsConst.UserAddTestUsers, null);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
