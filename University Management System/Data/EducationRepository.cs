using University_Management_System.Model.Domain;

namespace University_Management_System.Data
{
    public class EducationRepository
    {
        private readonly UniversityDbContext _context;

        public EducationRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public List<Education> GetTeachersEducations()
        {
            return _context.TeachersEducation.ToList();
        }

        public Education GetEducationtion(string EducationtName)
        {
            var Education = _context.TeachersEducation.FirstOrDefault(x => x.EducationName == EducationtName);
            if (Education == null)
            {
                return null;
            }
            return Education;
        }

        public Education AddEducation(Education Education)
        {
            _context.TeachersEducation.Add(Education);  
            _context.SaveChanges();
            return Education;
        }

        public Education RemoveEducation(string EducationName)
        {
            var Education = GetEducationtion(EducationName);
            if (EducationName != null)
            {
                _context.TeachersEducation.Remove(Education);
                _context.SaveChanges();
                return Education;
            }
            return null;
        }
    }
}
