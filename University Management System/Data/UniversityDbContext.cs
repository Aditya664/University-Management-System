using Microsoft.EntityFrameworkCore;
using University_Management_System.Model.Domain;

namespace University_Management_System.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Login> Login { get; set; }
        public DbSet<Course>  Courses { get; set; }
        public DbSet<Branch>  Branches { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
