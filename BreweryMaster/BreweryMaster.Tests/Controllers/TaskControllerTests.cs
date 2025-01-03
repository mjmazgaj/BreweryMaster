using BreweryMaster.API.WorkModule.Controllers;
using BreweryMaster.API.WorkModule.Models;
using BreweryMaster.API.WorkModule.Models.Dtos;
using BreweryMaster.API.WorkModule.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BreweryMaster.Tests.Controllers
{
    public class TaskControllerTests
    {
        private readonly Mock<ITaskService> _mockTaskService;
        private readonly TaskController _controller;

        public TaskControllerTests()
        {
            _mockTaskService = new Mock<ITaskService>();
            _controller = new TaskController(_mockTaskService.Object);
        }

        [Fact]
        public async Task GetKanbanTasksByOwnerId_ReturnsOkResult_WithListOfTasks()
        {
            // Arrange
            int ownerId = 1;
            var columns = new Dictionary<string, Column>();
            columns.Add("key1", new Column() { Title = "" });
            columns.Add("key2", new Column() { Title = "" });
            _mockTaskService.Setup(service => service.GetKanbanTasksByOwnerIdAsync(ownerId)).ReturnsAsync(columns);

            // Act
            var result = await _controller.GetKanbanTasksByOwnerId(ownerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnTasks = Assert.IsType<Dictionary<string, Column>>(okResult.Value);
            Assert.Equal(2, returnTasks.Count);
        }

        [Fact]
        public async Task GetKanbanTasksByOrderId_ReturnsOkResult_WithListOfTasks()
        {
            // Arrange
            int orderId = 1;
            var tasks = new List<KanbanTask> { new KanbanTask() { Title = ""}, new KanbanTask() { Title = "" } };
            _mockTaskService.Setup(service => service.GetKanbanTasksByOrderIdAsync(orderId)).ReturnsAsync(tasks);

            // Act
            var result = await _controller.GetKanbanTasksByOrderId(orderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnTasks = Assert.IsType<List<KanbanTask>>(okResult.Value);
            Assert.Equal(2, returnTasks.Count);
        }

        [Fact]
        public async Task GetKanbanTaskById_ReturnsOkResult_WithTask()
        {
            // Arrange
            int taskId = 1;
            var task = new KanbanTask() { Title = "" };
            _mockTaskService.Setup(service => service.GetKanbanTaskByIdAsync(taskId)).ReturnsAsync(task);

            // Act
            var result = await _controller.GetKanbanTaskById(taskId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnTask = Assert.IsType<KanbanTask>(okResult.Value);
            Assert.NotNull(returnTask);
        }

        [Fact]
        public async Task CreateKanbanTask_ReturnsCreatedAtActionResult_WithCreatedTask()
        {
            // Arrange
            var kanbanTask = new KanbanTask() { Title = "" };
            _mockTaskService.Setup(service => service.CreateKanbanTaskAsync(kanbanTask)).ReturnsAsync(kanbanTask);

            // Act
            var result = await _controller.CreateKanbanTask(kanbanTask);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(TaskController.GetKanbanTaskById), createdAtActionResult.ActionName);
            Assert.Equal(kanbanTask.Id, createdAtActionResult.RouteValues["id"]);
            Assert.Equal(kanbanTask, createdAtActionResult.Value);
        }

        [Fact]
        public async Task EditKanbanTask_ReturnsOkResult_WhenEditedSuccessfully()
        {
            // Arrange
            int taskId = 1;
            var kanbanTask = new KanbanTask() { Title = "" };
            _mockTaskService.Setup(service => service.EditKanbanTaskAsync(taskId, kanbanTask)).ReturnsAsync(true);

            // Act
            var result = await _controller.EditKanbanTask(taskId, kanbanTask);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task EditKanbanTask_ReturnsNotFoundResult_WhenTaskNotFound()
        {
            // Arrange
            int taskId = 1;
            var kanbanTask = new KanbanTask() { Title = "" };
            _mockTaskService.Setup(service => service.EditKanbanTaskAsync(taskId, kanbanTask)).ReturnsAsync(false);

            // Act
            var result = await _controller.EditKanbanTask(taskId, kanbanTask);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditKanbanTaskStatus_ReturnsOkResult_WhenStatusEditedSuccessfully()
        {
            // Arrange
            var request = new List<KanbanTaskStatusSaveRequest>();
            _mockTaskService.Setup(service => service.EditKanbanTaskStatusAsync(request)).ReturnsAsync(true);

            // Act
            var result = await _controller.EditKanbanTaskStatus(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task EditKanbanTaskStatus_ReturnsBadRequestResult_WhenStatusNotEdited()
        {
            // Arrange
            var request = new List<KanbanTaskStatusSaveRequest>();
            _mockTaskService.Setup(service => service.EditKanbanTaskStatusAsync(request)).ReturnsAsync(false);

            // Act
            var result = await _controller.EditKanbanTaskStatus(request);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteKanbanTaskById_ReturnsOkResult_WhenDeletedSuccessfully()
        {
            // Arrange
            int taskId = 1;
            _mockTaskService.Setup(service => service.DeleteKanbanTaskByIdAsync(taskId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteKanbanTaskById(taskId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteKanbanTaskById_ReturnsNotFoundResult_WhenTaskNotFound()
        {
            // Arrange
            int taskId = 1;
            _mockTaskService.Setup(service => service.DeleteKanbanTaskByIdAsync(taskId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteKanbanTaskById(taskId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
