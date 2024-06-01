using BreweryMaster.API.Models.User;
using BreweryMaster.API.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly UserContext _userContext;
        public EmployeeController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_userContext.Employees == null)
                return NotFound();
            return await _userContext.Employees.ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> GetEmployeeById([MinIntValidation] int id)
        {
            if (_userContext.Employees == null)
                return NotFound();

            var employee = await _userContext.Employees.FirstOrDefaultAsync(x => x.ID == id);

            if (employee == null)
                return NotFound();

            return employee;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
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

            _userContext.Employees.Add(employeeToCreate);
            await _userContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeToCreate.ID }, employeeToCreate);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> EditEmployee([MinIntValidation] int id, [FromBody] Employee employee)
        {
            if (id != employee.ID)
                return BadRequest();

            _userContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                    return NotFound();
                else
                    throw;
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> DeleteEmployeeById([MinIntValidation] int id)
        {
            if (_userContext.Employees == null)
                return NotFound();

            var employee = await _userContext.Employees.FirstOrDefaultAsync(x => x.ID == id);

            if (employee == null)
                return NotFound();

            _userContext.Employees.Remove(employee);
            await _userContext.SaveChangesAsync();

            return Ok();
        }

        private bool ProductExists(int id)
        {
            return _userContext.Employees.Any(x => x.ID == id);
        }

    }
}
