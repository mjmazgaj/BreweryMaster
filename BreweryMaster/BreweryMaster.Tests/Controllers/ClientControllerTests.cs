using BreweryMaster.API.OrderModule.Controllers;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.OrderModule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;

namespace BreweryMaster.Tests.Controllers;
public class ClientControllerTests
{
    private readonly Mock<IProspectClientService> _mockClientService;
    private readonly Mock<IOptions<OrderSettings>> _mockOptions;
    private readonly ProspectClientController _controller;

    public ClientControllerTests()
    {
        _mockClientService = new Mock<IProspectClientService>();
        _mockOptions = new Mock<IOptions<OrderSettings>>();
        _controller = new ProspectClientController(_mockClientService.Object, _mockOptions.Object);
    }

    [Fact]
    public async Task GetClients_ReturnsOkResult_WithListOfClients()
    {
        // Arrange
        var clients = new List<ProspectClient> { new ProspectClient(), new ProspectClient() };
        _mockClientService.Setup(service => service.GetProspectClientsAsync()).ReturnsAsync(clients);

        // Act
        var result = await _controller.GetProspectClients();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnClients = Assert.IsType<List<ProspectClient>>(okResult.Value);
        Assert.Equal(2, returnClients.Count);
    }

    [Fact]
    public async Task GetClients_ReturnsNotFound_WhenNoClientsExist()
    {
        // Arrange
        _mockClientService.Setup(service => service.GetProspectClientsAsync()).ReturnsAsync((List<ProspectClient>)null);

        // Act
        var result = await _controller.GetProspectClients();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetProspectClientById_ReturnsOkResult_WithClient()
    {
        // Arrange
        var client = new ProspectClient { Id = 1 };
        _mockClientService.Setup(service => service.GetProspectClientByIdAsync(1)).ReturnsAsync(client);

        // Act
        var result = await _controller.GetProspectClientById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnClient = Assert.IsType<ProspectClient>(okResult.Value);
        Assert.Equal(1, returnClient.Id);
    }

    [Fact]
    public async Task GetProspectClientById_ReturnsNotFound_WhenClientDoesNotExist()
    {
        // Arrange
        _mockClientService.Setup(service => service.GetProspectClientByIdAsync(1)).ReturnsAsync(default(ProspectClient));

        // Act
        var result = await _controller.GetProspectClientById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateProspectClient_ReturnsCreatedAtAction_WithCreatedClient()
    {
        // Arrange
        var clientRequest = new ProspectClientRequest { Forename = "test", Email = "test@test.test" };
        var client = new ProspectClient { Forename = "test", Email = "test@test.test" };
        _mockClientService.Setup(service => service.CreateProspectClientAsync(clientRequest)).ReturnsAsync(client);

        // Act
        var result = await _controller.CreateProspectClient(clientRequest);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnClient = Assert.IsType<ProspectClient>(createdAtActionResult.Value);
        Assert.Equal(1, returnClient.Id);
    }

    [Fact]
    public async Task EditProspectClient_ReturnsOk_WhenClientIsEdited()
    {
        // Arrange
        var client = new ProspectClient { Id = 1 };
        _mockClientService.Setup(service => service.EditProspectClientAsync(1, client)).ReturnsAsync(true);

        // Act
        var result = await _controller.EditProspectClient(1, client);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task EditProspectClient_ReturnsNotFound_WhenClientDoesNotExist()
    {
        // Arrange
        var client = new ProspectClient { Id = 1 };
        _mockClientService.Setup(service => service.EditProspectClientAsync(1, client)).ReturnsAsync(false);

        // Act
        var result = await _controller.EditProspectClient(1, client);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteProspectClientById_ReturnsOk_WhenClientIsDeleted()
    {
        // Arrange
        _mockClientService.Setup(service => service.DeleteProspectClientByIdAsync(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteProspectClientById(1);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteProspectClientById_ReturnsNotFound_WhenClientDoesNotExist()
    {
        // Arrange
        _mockClientService.Setup(service => service.DeleteProspectClientByIdAsync(1)).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteProspectClientById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
