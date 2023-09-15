using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Management_System.Model.Domain
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int RollNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? ClassXIIPer { get; set; }

        [ForeignKey("Course")]
        public string CourseName { get; set; }
        public Course Course { get; set; }

        public string FatherName { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset DOB { get; set; }

        [Phone]
        public string PhoneNo { get; set; }

        public int? ClassXPer { get; set; }
        public int? AdharNo { get; set; }

        [Required]
        [ForeignKey("Branch")]
        public string BranchName { get; set; }
        public Branch Branch { get; set; }
    }
}
