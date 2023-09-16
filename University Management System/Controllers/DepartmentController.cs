using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Data;
using University_Management_System.Model.Domain;

namespace University_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController(DepartmentRepository _departmentRepository)
        {
            _departmentRepository = _departmentRepository;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            return Ok(_departmentRepository.GetDepartments());
        }

        [HttpGet("{departmentName}")]
        public IActionResult GetDepartment(string departmentName) 
        {
            var department = _departmentRepository.GetDepartment(departmentName);
            if(department == null) 
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(string departmentName)
        {
            var department = _departmentRepository.RemoveDepartment(departmentName);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult AddDeparetment(Department department)
        {
            _departmentRepository.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartment),new { departmentName = department.DepartmentName }, department);
        }
    }
}
