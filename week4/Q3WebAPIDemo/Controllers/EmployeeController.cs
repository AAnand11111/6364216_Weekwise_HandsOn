using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q3WebAPIDemo.Models;
using Q3WebAPIDemo.Filters;

namespace Q3WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();

        // Constructor to create sample data
        public EmployeeController()
        {
            if (employees.Count == 0)
            {
                employees = GetStandardEmployeeList();
            }
        }

        // Private method to create standard employee list
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Department = new Department { Id = 1, Name = "IT", Location = "New York" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#", Level = "Advanced" },
                        new Skill { Id = 2, Name = "ASP.NET", Level = "Intermediate" }
                    }
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Salary = 75000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1985, 8, 22),
                    Department = new Department { Id = 2, Name = "HR", Location = "California" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 3, Name = "Leadership", Level = "Advanced" },
                        new Skill { Id = 4, Name = "Communication", Level = "Expert" }
                    }
                },
                new Employee
                {
                    Id = 3,
                    Name = "Bob Johnson",
                    Salary = 45000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1992, 12, 10),
                    Department = new Department { Id = 3, Name = "Finance", Location = "Texas" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 5, Name = "Excel", Level = "Advanced" },
                        new Skill { Id = 6, Name = "Accounting", Level = "Intermediate" }
                    }
                }
            };
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> GetStandard()
        {
            // Uncomment this line to test exception filter
            // throw new Exception("Test exception for exception filter");

            return Ok(employees);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required");
            }

            employee.Id = employees.Count + 1;
            employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required");
            }

            var existingEmployee = employees.Find(e => e.Id == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Permanent = employee.Permanent;
            existingEmployee.DateOfBirth = employee.DateOfBirth;
            existingEmployee.Department = employee.Department;
            existingEmployee.Skills = employee.Skills;

            return Ok(existingEmployee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            employees.Remove(employee);
            return Ok("Employee deleted successfully");
        }
    }
}