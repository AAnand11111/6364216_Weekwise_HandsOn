using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIJWTDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Basic authorization - any valid JWT token
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = new[]
            {
                new { Id = 1, Name = "John Doe", Department = "IT" },
                new { Id = 2, Name = "Jane Smith", Department = "HR" },
                new { Id = 3, Name = "Bob Johnson", Department = "Finance" }
            };

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = new { Id = id, Name = "Sample Employee", Department = "IT" };
            return Ok(employee);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Only Admin role can create employees
        public IActionResult CreateEmployee([FromBody] dynamic employee)
        {
            return Ok(new { Message = "Employee created successfully", Data = employee });
        }
    }
}