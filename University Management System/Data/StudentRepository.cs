﻿using AutoMapper;
using University_Management_System.Model.Domain;
using University_Management_System.Model.DTO;

namespace University_Management_System.Data
{
    public class StudentRepository
    {
        private readonly UniversityDbContext universityDbContext;
        private readonly IMapper _mapper;

        public StudentRepository(UniversityDbContext universityDbContext,IMapper mapper)
        {
            this._mapper = mapper;
            this.universityDbContext = universityDbContext;
        }

        public List<Student> GetAll()
        {
            return universityDbContext.Students.ToList();
        }

        public List<Student> FindByName(string name)
        {
            var student = universityDbContext.Students.Where(x => x.Name == name.ToLower());
            if(student == null)
            {
                return null;
            }
            return student.ToList();
        }

        public Student FindById(int id)
        {
            var student = universityDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public Student AddStudent(StudentDto student)
        {
           var newStudent = _mapper.Map<Student>(student);
           universityDbContext.Students.Add(newStudent);
           universityDbContext.SaveChanges();
           return newStudent;
        }

        public Student UpdateStudent(int id,StudentDto student)
        {
            var oldStudent = universityDbContext.Students.FirstOrDefault(x => x.Id==id);
            if(oldStudent == null)
            {
                return null;
            }
            _mapper.Map(student, oldStudent);
            universityDbContext.SaveChanges();
            return oldStudent;
        }
        public Student DeleteStudent(int id)
        {
            var oldStudent = universityDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (oldStudent == null)
            {
                return null;
            }
            universityDbContext.Students.Remove(oldStudent);
            universityDbContext.SaveChanges();
            return oldStudent;
        }

    }
}
