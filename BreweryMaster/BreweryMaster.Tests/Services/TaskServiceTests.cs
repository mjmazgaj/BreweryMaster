using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BreweryMaster.API.Configuration.Models;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Services;
using BreweryMaster.API.Work.Models.DB;
using BreweryMaster.API.WorkModule.Services;
using BreweryMaster.API.Work.Models.Requests;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.Tests.Models;
using BreweryMaster.API.WorkModule.Models;
using BreweryMaster.API.Work.Models;
using System.Security.Claims;
using BreweryMaster.API.User.Models.Users;

namespace BreweryMaster.Tests.Services;

public class KanbanTaskServiceTests
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly Mock<IOptions<WorkSettings>> _optionsMock;
    private readonly ApplicationDbContext _dbContext;

    public KanbanTaskServiceTests()
    {
        _userServiceMock = new Mock<IUserService>();
        _optionsMock = new Mock<IOptions<WorkSettings>>();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _dbContext = new ApplicationDbContext(options);

        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();

        SeedDatabase();
    }

    private void SeedDatabase()
    {
        if (_dbContext.TaskStatusEntities.Any() || _dbContext.KanbanTasks.Any() || _dbContext.Users.Any())
            return;
        
        var user1 = new ApplicationUser { Id = TestConst.User1, UserName = TestConst.User1 };
        var user2 = new ApplicationUser { Id = TestConst.User2, UserName = TestConst.User2 };

        _dbContext.Users.AddRange(user1, user2);

        var status1 = new TaskStatusEntity { Id = 1, Name = TestConst.Status1 };
        var status2 = new TaskStatusEntity { Id = 2, Name = TestConst.Status2 };

        _dbContext.TaskStatusEntities.AddRange(status1, status2);

        _dbContext.KanbanTasks.AddRange(
            new KanbanTask { Id = 1, Title = TestConst.String, StatusId= status1.Id, Status = null!, CreatedById = TestConst.User1, CreatedBy = null!, IsRemoved = false },
            new KanbanTask { Id = 2, Title = TestConst.String, StatusId = status1.Id, Status = null!, CreatedById = TestConst.User2, CreatedBy = null!, IsRemoved = false },
            new KanbanTask { Id = 3, Title = TestConst.String, StatusId = status2.Id, Status = null!, CreatedById = TestConst.User1, CreatedBy = null!, IsRemoved = true }
        );

        _dbContext.SaveChanges();
    }

    [Theory]
    [InlineData(null, null, null)]
    [InlineData(TestConst.User1, null, null)]
    [InlineData(null, TestConst.User1, null)]
    [InlineData(null, null, 1)]
    public async Task GetKanbanTasks_ShouldFilter_ByProvidedParameters(string? createdById, string? assignedToId, int? orderId)
    {
        // Arrange
        var service = new TaskService(_dbContext, _userServiceMock.Object, _optionsMock.Object);
        var filter = new KanbanTaskFilterRequest
        {
            CreatedById = createdById,
            AssignedToId = assignedToId,
            OrderId = orderId,
        };

        var expectedResult = _dbContext.KanbanTasks
                                .Where(x => !x.IsRemoved)
                                .Where(x => string.IsNullOrEmpty(assignedToId) || x.AssignedToId == assignedToId)
                                .Where(x => string.IsNullOrEmpty(createdById) || x.CreatedById == createdById)
                                .Where(x => orderId == null || x.OrderId == orderId)
                                .ToList();
        // Act
        var result = await service.GetKanbanTasks(filter);

        // Assert
        int actualTaskCount = result.Values.SelectMany(group => group.Items ?? Enumerable.Empty<KanbanTaskResponse>()).Count();

        Assert.NotNull(result);
        Assert.Equal(expectedResult.Count, actualTaskCount);
    }

    [Fact]
    public async Task CreateKanbanTaskAsync_ShouldCreateTask_WhenUserIsAuthenticated()
    {
        // Arrange
        var service = new TaskService(_dbContext, _userServiceMock.Object, _optionsMock.Object);

        var mockUser = new UserResponse { Id = TestConst.User1, Email = TestConst.Email1 };
        _userServiceMock
            .Setup(x => x.GetCurrentUser(It.IsAny<ClaimsPrincipal>()))
            .ReturnsAsync(mockUser);

        var kanbanTaskRequest = new KanbanTaskRequest
        {
            Title = TestConst.Title,
            Summary = TestConst.Summary,
            DueDate = DateTime.UtcNow.AddDays(3)
        };

        // Act
        var result = await service.CreateKanbanTaskAsync(kanbanTaskRequest, new ClaimsPrincipal());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(mockUser.Id, result.CreatedById);
        Assert.Equal(kanbanTaskRequest.Title, result.Title);
        Assert.Equal(kanbanTaskRequest.Summary, result.Summary);
        Assert.Equal(kanbanTaskRequest.DueDate, result.DueDate);
        Assert.Equal(1, result.StatusId);
        Assert.Equal(mockUser.Email, result.CreatedBy);
    }
}
