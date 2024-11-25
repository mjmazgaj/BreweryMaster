using BreweryMaster.API.Shared;
using BreweryMaster.API.User.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreweryMaster.API.User.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            var employeeToCreate = new Employee()
            {
                UserId = employee.UserId,
                Forename = employee.Forename,
                Surname = employee.Surname,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
            };

            _context.Employees.Add(employeeToCreate);
            await _context.SaveChangesAsync();

            return employeeToCreate;
        }

        public async Task<bool> EditEmployeeAsync(int id, Employee employee)
        {
            if (id != employee.ID)
                return false;

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<bool> DeleteEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.ID == id);

            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(x => x.ID == id);
        }
    }
}
