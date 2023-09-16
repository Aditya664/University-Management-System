using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Data;
using University_Management_System.Model.Domain;

namespace University_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersEducationController : Controller
    {
        private readonly EducationRepository _educationRepository;

        public TeachersEducationController(EducationRepository _educationRepository)
        {
            _educationRepository = _educationRepository;
        }

        [HttpGet]
        public IActionResult GetAllEducations()
        {
            return Ok(_educationRepository.GetTeachersEducations());
        }

        [HttpGet("{educationName}")]
        public IActionResult GetEducation(string educationName) 
        {
            var education = _educationRepository.GetEducationtion(educationName);
            if(education == null) 
            {
                return NotFound();
            }
            return Ok(education);
        }

        [HttpDelete]
        public IActionResult DeleteEducation(string educationName)
        {
            var education = _educationRepository.RemoveEducation(educationName);
            if (education == null)
            {
                return NotFound();
            }
            return Ok(education);
        }

        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            _educationRepository.AddEducation(education);
            return CreatedAtAction(nameof(GetEducation),new { educationName = education.EducationName }, education);
        }
    }
}
