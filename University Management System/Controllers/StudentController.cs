using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Data;
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
            this.studentRepository = studentRepository;
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
            if(newStud == null)
            {
                return BadRequest("Incorrect student information");
            }
            return CreatedAtAction(nameof(GetStudentById), new { id = newStud.Id }, newStud);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            var isStudentExist = studentRepository.FindById(id);
            if(isStudentExist == null)
            {
                return BadRequest("Student Not Exists");
            }
            return Ok(isStudentExist);
        }

        [HttpGet("{name}")]
        public IActionResult GetStudentByName(string name)
        {
            var isStudentExist = studentRepository.FindByName(name);
            if (isStudentExist == null)
            {
                return BadRequest("Student Not Exists");
            }
            return Ok(isStudentExist);
        }
    }
}
