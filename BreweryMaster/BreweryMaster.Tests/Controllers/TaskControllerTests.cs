using System.Net;
using Moq;
using BreweryMaster.API.WorkModule.Models;
using BreweryMaster.Tests.Models;
using BreweryMaster.API.Work.Models.Requests;
using Microsoft.AspNetCore.WebUtilities;
using BreweryMaster.API.Work.Models;
using System.Security.Claims;
using System.Net.Http.Json;
using BreweryMaster.API.Configuration.Enums;

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

    [Theory]
    [InlineData(TestConst.String, TestConst.String, TestConst.Date, HttpStatusCode.Created)]
    [InlineData(null, TestConst.String, TestConst.Date, HttpStatusCode.BadRequest)]
    [InlineData(TestConst.String, null, TestConst.Date, HttpStatusCode.Created)]
    [InlineData(TestConst.String, TestConst.String, null, HttpStatusCode.BadRequest)]
    public async Task CreateKanbanTask_ShouldReturnProperResponse(string? title, string? summary, string? dueDateString, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        DateTime? dueDate = string.IsNullOrEmpty(dueDateString) ? (DateTime?)null : DateTime.Parse(dueDateString);

        var request = new KanbanTaskRequest
        {
            Title = title,
            Summary = summary,
            DueDate = dueDate ?? default,
        };

        MockTaskService.Setup(s => s.CreateKanbanTaskAsync(It.IsAny<KanbanTaskRequest>(), It.IsAny<ClaimsPrincipal>()))
            .ReturnsAsync(new KanbanTaskResponse());

        // Act
        var httpResponse = await Client.PostAsJsonAsync(EndpointsConst.Task, request);

        // Assert
        Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
    }

    [Theory]
    [InlineData(1, 1, HttpStatusCode.OK)]
    [InlineData(1, null, HttpStatusCode.BadRequest)]
    [InlineData(null, 1, HttpStatusCode.BadRequest)]
    public async Task CreateKanbanTaskTemplates_ShouldReturnProperResponse(int? orderId, int? orderStatus, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        var request = new KanbanTaskTemplateRequest
        {
            OrderId = orderId ?? default,
            OrderStatus = (OrderStatus)(orderStatus ?? default),
        };

        MockTaskService.Setup(s => s.CreateKanbanTaskTemplates(It.IsAny<KanbanTaskTemplateRequest>(), It.IsAny<ClaimsPrincipal>()))
            .ReturnsAsync(new List<KanbanTaskResponse>());

        // Act
        var httpResponse = await Client.PostAsJsonAsync(EndpointsConst.TaskTemplate, request);

        // Assert
        Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
    }

    [Theory]
    [InlineData(1, TestConst.String, TestConst.String, TestConst.String, TestConst.Date, HttpStatusCode.OK)]
    [InlineData(1, null, TestConst.String, TestConst.String, TestConst.Date, HttpStatusCode.OK)]
    [InlineData(1, TestConst.String, null, TestConst.String, TestConst.Date, HttpStatusCode.BadRequest)]
    [InlineData(1, TestConst.String, TestConst.String, null, TestConst.Date, HttpStatusCode.OK)]
    [InlineData(1, TestConst.String, TestConst.String, TestConst.String, null, HttpStatusCode.BadRequest)]
    [InlineData(0, TestConst.String, TestConst.String, TestConst.String, TestConst.Date, HttpStatusCode.BadRequest)]
    [InlineData(1, TestConst.String451Characters, TestConst.String, TestConst.String, TestConst.Date, HttpStatusCode.BadRequest)]
    [InlineData(1, TestConst.String, TestConst.String256Characters, TestConst.String, TestConst.Date, HttpStatusCode.BadRequest)]
    public async Task EditKanbanTask_ShouldReturnProperResponse(int? id, string? assignedToId, string? title, string? summary, string? dueDateString, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        DateTime? dueDate = string.IsNullOrEmpty(dueDateString) ? (DateTime?)null : DateTime.Parse(dueDateString);

        var request = new KanbanTaskUpdateRequest
        {
            Id = id ?? 0,
            AssignedToId = assignedToId,
            Title = title,
            Summary = summary,
            DueDate = dueDate ?? default,
        };

        MockTaskService.Setup(s => s.EditKanbanTaskAsync(It.IsAny<int>(), It.IsAny<KanbanTaskUpdateRequest>()))
            .ReturnsAsync(true);

        // Act
        var httpResponse = await Client.PatchAsJsonAsync($"{EndpointsConst.Task}/{id}", request);

        // Assert
        Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
    }

    [Theory]
    [MemberData(nameof(GetEditKanbanTaskStatusTestData))]
    public async Task EditKanbanTaskStatus_ShouldReturnProperResponse(List<KanbanTaskStatusRequest> request, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        MockTaskService.Setup(s => s.EditKanbanTaskStatusAsync(It.IsAny<List<KanbanTaskStatusRequest>>()))
            .ReturnsAsync(true);

        // Act
        var httpResponse = await Client.PatchAsJsonAsync(EndpointsConst.TaskStatus, request);

        // Assert
        Assert.Equal(expectedStatusCode, httpResponse.StatusCode);
    }

    public static IEnumerable<object[]> GetEditKanbanTaskStatusTestData()
    {
        yield return new object[] { new List<KanbanTaskStatusRequest> { new KanbanTaskStatusRequest { Id = 1, Status = 1 } }, HttpStatusCode.OK };
        yield return new object[] { new List<KanbanTaskStatusRequest> { new KanbanTaskStatusRequest { Id = 1, Status = default } }, HttpStatusCode.BadRequest };
        yield return new object[] { new List<KanbanTaskStatusRequest> { new KanbanTaskStatusRequest { Id = default, Status = 1 } }, HttpStatusCode.BadRequest };
    }
}
