using System.Net;
using Moq;
using BreweryMaster.API.WorkModule.Models;
using BreweryMaster.Tests.Models;
using BreweryMaster.API.Work.Models.Requests;
using Microsoft.AspNetCore.WebUtilities;

namespace BreweryMaster.Tests.Controllers;

public class TaskControllerTests : BaseTestController
{
    [Theory]
    [InlineData(TestConst.String, TestConst.String, 1, HttpStatusCode.OK)]
    [InlineData(TestConst.String, TestConst.String, null, HttpStatusCode.OK)]
    [InlineData(TestConst.String, null, 1, HttpStatusCode.OK)]
    [InlineData(null, TestConst.String, 1, HttpStatusCode.OK)]
    [InlineData(TestConst.String, TestConst.String, -1, HttpStatusCode.BadRequest)]
    [InlineData(TestConst.String, TestConst.String451Characters, 1, HttpStatusCode.BadRequest)]
    [InlineData(TestConst.String451Characters, TestConst.String, 1, HttpStatusCode.BadRequest)]
    public async Task GetKanbanTasks_ShouldReturnProperResponse(string? createdById, string? assignedToId, int? orderId, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        var queryParams = new Dictionary<string, string?>()
        {
            { "CreatedById", createdById },
            { "AssignedToId", assignedToId },
            { "OrderId", orderId?.ToString() }
        };

        var response = new Dictionary<string, KanbanTaskGroupResponse>();

        var url = QueryHelpers.AddQueryString(EndpointsConst.Task, queryParams);

        MockTaskService.Setup(s => s.GetKanbanTasks(It.IsAny<KanbanTaskFilterRequest>()))
            .ReturnsAsync(response);

        // Act
        var httpResponse = await Client.GetAsync(url);

        // Assert
        Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
    }

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
