using University_Management_System.Model.Domain;

namespace University_Management_System.Data
{
    public class LoginRepository
    {
        private readonly UniversityDbContext _context;

        public LoginRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public Login FindByEmailAndPassword(string email, string password)
        {
            return _context.Login.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
