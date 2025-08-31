using EF_DB_FIRST_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_DB_FIRST_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDBContext _context;

        public StudentsController(StudentDBContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_context.Students.ToList());
        }

      
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            var existingStudent = _context.Students
                .FirstOrDefault(s => s.Name == student.Name);
            if (existingStudent != null)
            {
                return BadRequest("Student Name already exists.");
            }

            if (student.Age <= 18)
            {
                return BadRequest("Age must be 18 up.");
            }

            if (student.CGPA < 3.00m)
            {
                return BadRequest("CGPA must be at least 3.00.");
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var existing = _context.Students.Find(id);
            if (existing == null) return NotFound();

            existing.Name = student.Name;
            existing.Age = student.Age;
            existing.CGPA = student.CGPA;

            _context.SaveChanges();
            return NoContent();
        }

 
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
