using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Data;
using University_Management_System.Model.Domain;
using University_Management_System.Model.DTO;

namespace University_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentRepository studentRepository;

        public StudentController(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository)); ;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(studentRepository.GetAll());
        }

        [HttpPost]
        public IActionResult PostStudents([FromBody] StudentDto student)
        {
            var newStud = studentRepository.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = newStud.Id }, newStud);
        }

        [HttpGet("{id:int}", Name = nameof(GetStudentById))]
        public IActionResult GetStudentById(int id)
        {
            var isStudentExist = studentRepository.FindById(id);
            if(isStudentExist == null)
            {
                return NotFound();
            }
            return Ok(isStudentExist);
        }

        [HttpGet("{name}", Name = nameof(GetStudentByName))]
        public IActionResult GetStudentByName(string name)
        {
            var isStudentExist = studentRepository.FindByName(name);
            if (isStudentExist == null)
            {
                return NotFound();
            }
            return Ok(isStudentExist);
        }

        [HttpDelete]
        public IActionResult DeleteStudentById(int id)
        {
            var student = studentRepository.DeleteStudent(id);
            if(student == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDto student)
        {
            var updatedStudent = studentRepository.UpdateStudent(id, student);
            if(updatedStudent == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok();
        }
    }
}
