using University_Management_System.Model.Domain;

namespace University_Management_System.Data
{
    public class CourseRepository
    {
        private readonly UniversityDbContext _context;

        public CourseRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourse(string CourseName)
        {
            var Course = _context.Courses.FirstOrDefault(x => x.CourseName == CourseName);
            if (Course == null)
            {
                return null;
            }
            return Course;
        }

        public Course AddCourse(Course Course)
        {
            _context.Courses.Add(Course);
            _context.SaveChanges();
            return Course;
        }

        public Course RemoveCourse(string CourseName)
        {
            var Course = GetCourse(CourseName);
            if (Course != null)
            {
                _context.Courses.Remove(Course);
                _context.SaveChanges();
                return Course;
            }
            return null;
        }
    }
}

