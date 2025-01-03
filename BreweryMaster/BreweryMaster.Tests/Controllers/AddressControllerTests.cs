using BreweryMaster.API.UserModule.Controllers;
using BreweryMaster.API.UserModule.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BreweryMaster.Tests.Controllers;

public class AddressControllerTests
{
    private readonly Mock<IAddressService> _mockAddressService;
    private readonly AddressController _controller;

    public AddressControllerTests()
    {
        _mockAddressService = new Mock<IAddressService>();
        _controller = new AddressController(_mockAddressService.Object);
    }

    [Fact]
    public async Task GetAddresses_ReturnsOkResult_WithListOfAddresses()
    {
        // Arrange
        var addresses = new List<Address> { new Address(), new Address() };
        _mockAddressService.Setup(service => service.GetAddressesAsync()).ReturnsAsync(addresses);

        // Act
        var result = await _controller.GetAddresses();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnAddresses = Assert.IsType<List<Address>>(okResult.Value);
        Assert.Equal(2, returnAddresses.Count);
    }

    [Fact]
    public async Task GetAddresses_ReturnsNotFound_WhenNoAddressesExist()
    {
        // Arrange
        _mockAddressService.Setup(service => service.GetAddressesAsync()).ReturnsAsync((List<Address>)null);

        // Act
        var result = await _controller.GetAddresses();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetAddressById_ReturnsOkResult_WithAddress()
    {
        // Arrange
        var address = new Address { Id = 1 };
        _mockAddressService.Setup(service => service.GetAddressByIdAsync(1)).ReturnsAsync(address);

        // Act
        var result = await _controller.GetAddressById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnAddress = Assert.IsType<Address>(okResult.Value);
        Assert.Equal(1, returnAddress.Id);
    }

    [Fact]
    public async Task GetAddressById_ReturnsNotFound_WhenAddressDoesNotExist()
    {
        // Arrange
        _mockAddressService.Setup(service => service.GetAddressByIdAsync(1)).ReturnsAsync(default(Address));

        // Act
        var result = await _controller.GetAddressById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateAddress_ReturnsCreatedAtAction_WithCreatedAddress()
    {
        // Arrange
        var address = new Address { Id = 1 };
        _mockAddressService.Setup(service => service.CreateAddressAsync(address)).ReturnsAsync(address);

        // Act
        var result = await _controller.CreateAddress(address);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnAddress = Assert.IsType<Address>(createdAtActionResult.Value);
        Assert.Equal(1, returnAddress.Id);
    }

    [Fact]
    public async Task EditAddress_ReturnsOk_WhenAddressIsEdited()
    {
        // Arrange
        var address = new Address { Id = 1 };
        _mockAddressService.Setup(service => service.EditAddressAsync(1, address)).ReturnsAsync(true);

        // Act
        var result = await _controller.EditAddress(1, address);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task EditAddress_ReturnsNotFound_WhenAddressDoesNotExist()
    {
        // Arrange
        var address = new Address { Id = 1 };
        _mockAddressService.Setup(service => service.EditAddressAsync(1, address)).ReturnsAsync(false);

        // Act
        var result = await _controller.EditAddress(1, address);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteAddressById_ReturnsOk_WhenAddressIsDeleted()
    {
        // Arrange
        _mockAddressService.Setup(service => service.DeleteAddressByIdAsync(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteAddressById(1);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteAddressById_ReturnsNotFound_WhenAddressDoesNotExist()
    {
        // Arrange
        _mockAddressService.Setup(service => service.DeleteAddressByIdAsync(1)).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteAddressById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
