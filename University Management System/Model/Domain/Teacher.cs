using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Management_System.Model.Domain
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int EmployeeId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? ClassXIIPer { get; set; }

        [ForeignKey("Education")]
        public string EducationName { get; set; }
        public Education Education { get; set; }

        public string FatherName { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset DOB { get; set; }

        [Phone]
        public string PhoneNo { get; set; }

        public int? ClassXPer { get; set; }
        public int? AdharNo { get; set; }

        [Required]
        [ForeignKey("Department")]
        public string DepartmentName { get; set; }
        public Department Department { get; set; }
    }
}
