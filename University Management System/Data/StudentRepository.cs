using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using University_Management_System.Model.Domain;
using University_Management_System.Model.DTO;

namespace University_Management_System.Data
{
    public class StudentRepository
    {
        private readonly UniversityDbContext universityDbContext;
        private readonly IMapper _mapper;

        public StudentRepository(UniversityDbContext universityDbContext, IMapper mapper)
        {
            this._mapper = mapper;
            this.universityDbContext = universityDbContext;
        }

        public List<StudentResponseDto> GetAll()
        {
            var students = universityDbContext.Students.ToList();
            var studentResponseList = _mapper.Map<List<StudentResponseDto>>(students);
            return studentResponseList;
        }

        public List<StudentResponseDto> FindByName(string name)
        {
            var student = universityDbContext.Students.Where(x => x.Name == name.ToLower());
            if (student == null)
            {
                return null;
            }
            var studentResponse = _mapper.Map<List<StudentResponseDto>>(student);
            return studentResponse;
        }

        public StudentResponseDto FindByIdOrRollNo(string operationOn,int id)
        {
            if(operationOn == "RollNo")
            {
                var student = universityDbContext.Students.FirstOrDefault(x => x.RollNo == id);
                if (student == null)
                {
                    return null;
                }
                return _mapper.Map<StudentResponseDto>(student);
            }
            else if(operationOn == "Id")
            {
                var student = universityDbContext.Students.FirstOrDefault(x => x.Id == id);
                if (student == null)
                {
                    return null;
                }
                return _mapper.Map<StudentResponseDto>(student);
            }
            else
            {
                return null;
            }
        }

        public StudentResponseDto AddStudent(StudentDto student)
        {
            var newStudent = _mapper.Map<Student>(student);
            universityDbContext.Students.Add(newStudent);
            universityDbContext.SaveChanges();
            return _mapper.Map<StudentResponseDto>(newStudent);
        }

        public StudentResponseDto UpdateStudent(int id, StudentDto student)
        {
            var oldStudent = universityDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (oldStudent == null)
            {
                return null;
            }
            _mapper.Map(student, oldStudent);
            universityDbContext.SaveChanges();
            return _mapper.Map<StudentResponseDto>(oldStudent);
        }
        public StudentResponseDto DeleteStudent(int id)
        {
            var oldStudent = universityDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (oldStudent == null)
            {
                return null;
            }
            universityDbContext.Students.Remove(oldStudent);
            universityDbContext.SaveChanges();
            return _mapper.Map<StudentResponseDto>(oldStudent);
        }

        public List<RollNoDto> GetAllRollNumbers()
        {
            var rollNos = universityDbContext.Students
                .Select(student => student.RollNo)
                .ToList();

            return _mapper.Map<List<RollNoDto>>(rollNos);
        }

    }
}
