using BreweryMaster.API.Models.User;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task<bool> EditEmployeeAsync(int id, Employee employee);
    Task<bool> DeleteEmployeeByIdAsync(int id);
}
