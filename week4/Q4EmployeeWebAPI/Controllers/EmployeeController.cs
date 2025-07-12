using Microsoft.AspNetCore.Mvc;
using EmployeeWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Hardcoded employee data for demonstration
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@company.com",
                Department = "IT",
                Salary = 50000,
                DateOfJoining = new DateTime(2020, 1, 15),
                IsActive = true
            },
            new Employee
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@company.com",
                Department = "HR",
                Salary = 45000,
                DateOfJoining = new DateTime(2021, 3, 10),
                IsActive = true
            },
            new Employee
            {
                Id = 3,
                FirstName = "Mike",
                LastName = "Johnson",
                Email = "mike.johnson@company.com",
                Department = "Finance",
                Salary = 55000,
                DateOfJoining = new DateTime(2019, 7, 20),
                IsActive = true
            },
            new Employee
            {
                Id = 4,
                FirstName = "Sarah",
                LastName = "Williams",
                Email = "sarah.williams@company.com",
                Department = "Marketing",
                Salary = 48000,
                DateOfJoining = new DateTime(2022, 2, 5),
                IsActive = true
            }
        };

        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required");
            }

            // Validate model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Generate new ID
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            // Check if the id value is lesser than or equal to 0
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // Check if employee exists in the hardcoded list
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Validate input data
            if (employee == null)
            {
                return BadRequest("Employee data is required");
            }

            // Validate model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the existing employee with new data
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.DateOfJoining = employee.DateOfJoining;
            existingEmployee.IsActive = employee.IsActive;

            // Return the updated employee
            return Ok(existingEmployee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            employees.Remove(employee);
            return Ok($"Employee with ID {id} has been deleted successfully");
        }

        // GET: api/Employee/department/{department}
        [HttpGet("department/{department}")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesByDepartment(string department)
        {
            if (string.IsNullOrEmpty(department))
            {
                return BadRequest("Department name is required");
            }

            var departmentEmployees = employees.Where(e =>
                e.Department.Equals(department, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!departmentEmployees.Any())
            {
                return NotFound($"No employees found in {department} department");
            }

            return Ok(departmentEmployees);
        }

        // GET: api/Employee/active
        [HttpGet("active")]
        public ActionResult<IEnumerable<Employee>> GetActiveEmployees()
        {
            var activeEmployees = employees.Where(e => e.IsActive).ToList();
            return Ok(activeEmployees);
        }
    }
}