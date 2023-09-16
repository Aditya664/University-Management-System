using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Data;
using University_Management_System.Model.Domain;

namespace University_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseRepository _courseRepository;

        public CourseController(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult GetAllCourse()
        {
            return Ok(_courseRepository.GetCourses());
        }

        [HttpGet("{courseName}")]
        public IActionResult GetCourse(string courseName) 
        {
            var course = _courseRepository.GetCourse(courseName);
            if(course == null) 
            {
                return BadRequest("Something went wrong");
            }
            return Ok(course);
        }

        [HttpDelete]
        public IActionResult DeleteCourse(string courseName)
        {
            var course = _courseRepository.RemoveCourse(courseName);
            if (course == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(course);
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            _courseRepository.AddCourse(course);
            return CreatedAtAction(nameof(GetCourse),new { courseName = course.CourseName }, course);
        }
    }
}
