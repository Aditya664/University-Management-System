using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace University_Management_System.Model.Domain
{
    [Keyless]
    public class Login
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
