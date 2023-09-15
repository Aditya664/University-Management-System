using System.ComponentModel.DataAnnotations;

namespace University_Management_System.Model.Domain
{
    public class Course
    {
        [Key]
        public string CourseName { get; set; }
    }
}

