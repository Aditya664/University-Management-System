using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using University_Management_System.Model.Domain;

namespace University_Management_System.Model.DTO
{
    public class StudentResponseDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? ClassXIIPer { get; set; }
        public string CourseName { get; set; }
        public string FatherName { get; set; }
        public DateTimeOffset DOB { get; set; }
        public string PhoneNo { get; set; }
        public int? ClassXPer { get; set; }
        public int? AdharNo { get; set; }
        public string BranchName { get; set; }
    }
}
