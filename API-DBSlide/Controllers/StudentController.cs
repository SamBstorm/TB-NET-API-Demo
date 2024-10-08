using API_DBSlide.Context;
using API_DBSlide.Models.StudentModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_DBSlide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentContext _studentContext;

        public StudentController(IStudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        // GET: api/<StudentController>
        [HttpGet]
        [ProducesResponseType<IEnumerable<Student>>(200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_studentContext.Get());
            }
            catch (SqlException ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        [ProducesResponseType<Student>(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_studentContext.Get(id));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return NotFound();
            }
            catch (SqlException ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/<StudentController>
        [HttpPost]
        [ProducesResponseType<int>(201)]
        [ProducesResponseType(500)]
        public IActionResult Post(Student student)
        {
            try
            {
                int id = _studentContext.Create(student);
                return CreatedAtAction(nameof(Get),new { id }, id); 
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, Student student)
        {
            try
            {
                _studentContext.Update(id, student);
                return NoContent();
            }
            catch (ArgumentOutOfRangeException) { return NotFound(); }
            catch (SqlException) { return StatusCode(500); }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentContext.Delete(id);
                return NoContent() ;
            }
            catch (ArgumentOutOfRangeException) { return NotFound(); }
            catch (SqlException) { return StatusCode(500); }
        }
    }
}
