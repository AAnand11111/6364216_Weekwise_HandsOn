using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // In-memory storage for demonstration
        private static List<string> _values = new List<string>
        {
            "Value1",
            "Value2",
            "Value3"
        };

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(new
                {
                    message = "Success",
                    data = _values,
                    count = _values.Count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id < 0 || id >= _values.Count)
                {
                    return NotFound(new { message = $"Value with id {id} not found" });
                }

                return Ok(new
                {
                    message = "Success",
                    data = _values[id],
                    index = id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // POST: api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return BadRequest(new { message = "Value cannot be empty or null" });
                }

                _values.Add(value);
                var newIndex = _values.Count - 1;

                return Created($"api/values/{newIndex}", new
                {
                    message = "Value created successfully",
                    data = value,
                    index = newIndex
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // PUT: api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            try
            {
                if (id < 0 || id >= _values.Count)
                {
                    return NotFound(new { message = $"Value with id {id} not found" });
                }

                if (string.IsNullOrEmpty(value))
                {
                    return BadRequest(new { message = "Value cannot be empty or null" });
                }

                var oldValue = _values[id];
                _values[id] = value;

                return Ok(new
                {
                    message = "Value updated successfully",
                    oldValue = oldValue,
                    newValue = value,
                    index = id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // DELETE: api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id < 0 || id >= _values.Count)
                {
                    return NotFound(new { message = $"Value with id {id} not found" });
                }

                var deletedValue = _values[id];
                _values.RemoveAt(id);

                return Ok(new
                {
                    message = "Value deleted successfully",
                    deletedValue = deletedValue,
                    remainingCount = _values.Count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // GET: api/values/count
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            return Ok(new
            {
                message = "Total count retrieved",
                count = _values.Count
            });
        }

        // DELETE: api/values (clear all)
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            try
            {
                var count = _values.Count;
                _values.Clear();

                return Ok(new
                {
                    message = "All values cleared",
                    deletedCount = count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
    }
}