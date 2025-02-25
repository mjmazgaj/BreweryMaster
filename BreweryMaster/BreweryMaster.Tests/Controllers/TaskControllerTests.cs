using System.Net;
using Moq;
using BreweryMaster.API.WorkModule.Models;
using BreweryMaster.Tests.Models;

namespace BreweryMaster.Tests.Controllers;

public class TaskControllerTests : BaseTestController
{
    [Theory]
    [InlineData(-1, HttpStatusCode.BadRequest)]
    [InlineData(0, HttpStatusCode.BadRequest)]
    [InlineData(1, HttpStatusCode.OK)]
    public async Task GetKanbanTaskById_ShouldReturnProperResponse(int? id, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        MockTaskService.Setup(s => s.GetKanbanTaskByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new KanbanTaskResponse());

        // Act
        var response = await Client.GetAsync($"{EndpointsConst.Task}/{id}");

        // Assert
        Assert.Equal(expectedStatusCode, response.StatusCode);
    }
}
