using BreweryMaster.API.Order.Controllers;
using BreweryMaster.API.Order.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BreweryMaster.Tests.Controllers;
public class ClientControllerTests
{
    private readonly Mock<IClientService> _mockClientService;
    private readonly ClientController _controller;

    public ClientControllerTests()
    {
        _mockClientService = new Mock<IClientService>();
        _controller = new ClientController(_mockClientService.Object);
    }

    [Fact]
    public async Task GetClients_ReturnsOkResult_WithListOfClients()
    {
        // Arrange
        var clients = new List<Client> { new Client(), new Client() };
        _mockClientService.Setup(service => service.GetClientsAsync()).ReturnsAsync(clients);

        // Act
        var result = await _controller.GetClients();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnClients = Assert.IsType<List<Client>>(okResult.Value);
        Assert.Equal(2, returnClients.Count);
    }

    [Fact]
    public async Task GetClients_ReturnsNotFound_WhenNoClientsExist()
    {
        // Arrange
        _mockClientService.Setup(service => service.GetClientsAsync()).ReturnsAsync((List<Client>)null);

        // Act
        var result = await _controller.GetClients();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetClientById_ReturnsOkResult_WithClient()
    {
        // Arrange
        var client = new Client { ID = 1 };
        _mockClientService.Setup(service => service.GetClientByIdAsync(1)).ReturnsAsync(client);

        // Act
        var result = await _controller.GetClientById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnClient = Assert.IsType<Client>(okResult.Value);
        Assert.Equal(1, returnClient.ID);
    }

    [Fact]
    public async Task GetClientById_ReturnsNotFound_WhenClientDoesNotExist()
    {
        // Arrange
        _mockClientService.Setup(service => service.GetClientByIdAsync(1)).ReturnsAsync((Client)null);

        // Act
        var result = await _controller.GetClientById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateClient_ReturnsCreatedAtAction_WithCreatedClient()
    {
        // Arrange
        var client = new Client { ID = 1 };
        _mockClientService.Setup(service => service.CreateClientAsync(client)).ReturnsAsync(client);

        // Act
        var result = await _controller.CreateClient(client);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnClient = Assert.IsType<Client>(createdAtActionResult.Value);
        Assert.Equal(1, returnClient.ID);
    }

    [Fact]
    public async Task EditClient_ReturnsOk_WhenClientIsEdited()
    {
        // Arrange
        var client = new Client { ID = 1 };
        _mockClientService.Setup(service => service.EditClientAsync(1, client)).ReturnsAsync(true);

        // Act
        var result = await _controller.EditClient(1, client);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task EditClient_ReturnsNotFound_WhenClientDoesNotExist()
    {
        // Arrange
        var client = new Client { ID = 1 };
        _mockClientService.Setup(service => service.EditClientAsync(1, client)).ReturnsAsync(false);

        // Act
        var result = await _controller.EditClient(1, client);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteClientById_ReturnsOk_WhenClientIsDeleted()
    {
        // Arrange
        _mockClientService.Setup(service => service.DeleteClientByIdAsync(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteClientById(1);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteClientById_ReturnsNotFound_WhenClientDoesNotExist()
    {
        // Arrange
        _mockClientService.Setup(service => service.DeleteClientByIdAsync(1)).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteClientById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
