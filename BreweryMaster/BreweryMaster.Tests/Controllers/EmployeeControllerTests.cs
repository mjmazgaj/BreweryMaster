using BreweryMaster.API.User.Controllers;
using BreweryMaster.API.User.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BreweryMaster.Tests.Controllers;
public class EmployeeControllerTests
{
    private readonly Mock<IEmployeeService> _mockEmployeeService;
    private readonly EmployeeController _controller;

    public EmployeeControllerTests()
    {
        _mockEmployeeService = new Mock<IEmployeeService>();
        _controller = new EmployeeController(_mockEmployeeService.Object);
    }

    [Fact]
    public async Task GetEmployees_ReturnsOkResult_WithListOfEmployees()
    {
        // Arrange
        var employees = new List<Employee> { new Employee(), new Employee() };
        _mockEmployeeService.Setup(service => service.GetEmployeesAsync()).ReturnsAsync(employees);

        // Act
        var result = await _controller.GetEmployees();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnEmployees = Assert.IsType<List<Employee>>(okResult.Value);
        Assert.Equal(2, returnEmployees.Count);
    }

    [Fact]
    public async Task GetEmployees_ReturnsNotFound_WhenNoEmployeesExist()
    {
        // Arrange
        _mockEmployeeService.Setup(service => service.GetEmployeesAsync()).ReturnsAsync((List<Employee>)null);

        // Act
        var result = await _controller.GetEmployees();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetEmployeeById_ReturnsOkResult_WithEmployee()
    {
        // Arrange
        var employee = new Employee { ID = 1 };
        _mockEmployeeService.Setup(service => service.GetEmployeeByIdAsync(1)).ReturnsAsync(employee);

        // Act
        var result = await _controller.GetEmployeeById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnEmployee = Assert.IsType<Employee>(okResult.Value);
        Assert.Equal(1, returnEmployee.ID);
    }

    [Fact]
    public async Task GetEmployeeById_ReturnsNotFound_WhenEmployeeDoesNotExist()
    {
        // Arrange
        _mockEmployeeService.Setup(service => service.GetEmployeeByIdAsync(1)).ReturnsAsync((Employee)null);

        // Act
        var result = await _controller.GetEmployeeById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateEmployee_ReturnsCreatedAtAction_WithCreatedEmployee()
    {
        // Arrange
        var employee = new Employee { ID = 1 };
        _mockEmployeeService.Setup(service => service.CreateEmployeeAsync(employee)).ReturnsAsync(employee);

        // Act
        var result = await _controller.CreateEmployee(employee);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnEmployee = Assert.IsType<Employee>(createdAtActionResult.Value);
        Assert.Equal(1, returnEmployee.ID);
    }

    [Fact]
    public async Task EditEmployee_ReturnsOk_WhenEmployeeIsEdited()
    {
        // Arrange
        var employee = new Employee { ID = 1 };
        _mockEmployeeService.Setup(service => service.EditEmployeeAsync(1, employee)).ReturnsAsync(true);

        // Act
        var result = await _controller.EditEmployee(1, employee);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task EditEmployee_ReturnsNotFound_WhenEmployeeDoesNotExist()
    {
        // Arrange
        var employee = new Employee { ID = 1 };
        _mockEmployeeService.Setup(service => service.EditEmployeeAsync(1, employee)).ReturnsAsync(false);

        // Act
        var result = await _controller.EditEmployee(1, employee);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteEmployeeById_ReturnsOk_WhenEmployeeIsDeleted()
    {
        // Arrange
        _mockEmployeeService.Setup(service => service.DeleteEmployeeByIdAsync(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteEmployeeById(1);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteEmployeeById_ReturnsNotFound_WhenEmployeeDoesNotExist()
    {
        // Arrange
        _mockEmployeeService.Setup(service => service.DeleteEmployeeByIdAsync(1)).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteEmployeeById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
