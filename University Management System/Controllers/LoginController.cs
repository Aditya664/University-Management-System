using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Management_System.Data;
using University_Management_System.Model.Domain;

namespace University_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginRepository _loginRepository;

        public LoginController(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            var user = _loginRepository.FindByEmailAndPassword(Email, Password);
            if (user == null)
            {
                return BadRequest("Invalid user");
            }
            return Ok();
        }
    }
}
