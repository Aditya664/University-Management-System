using System.ComponentModel.DataAnnotations;

namespace University_Management_System.Model.Domain
{
    public class Education
    {
        [Key]
        public string EducationName { get; set; }
    }
}