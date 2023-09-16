using University_Management_System.Model.Domain;

namespace University_Management_System.Data
{
    public class DepartmentRepository
    {
        private readonly UniversityDbContext _context;

        public DepartmentRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public List<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartment(string DepartmentName)
        {
            var Department = _context.Departments.FirstOrDefault(x => x.DepartmentName == DepartmentName);
            if (Department == null)
            {
                return null;
            }
            return Department;
        }

        public Department AddDepartment(Department Department)
        {
            _context.Departments.Add(Department);  
            _context.SaveChanges();
            return Department;
        }

        public Department RemoveDepartment(string DepartmentName)
        {
            var Department = GetDepartment(DepartmentName);
            if (Department != null)
            {
                _context.Departments.Remove(Department);
                _context.SaveChanges();
                return Department;
            }
            return null;
        }
    }
}
