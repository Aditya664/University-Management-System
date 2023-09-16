using System.ComponentModel.DataAnnotations;

namespace University_Management_System.Model.Domain
{
    public class Department
    {
        [Key]
        public string DepartmentName { get; set; }
    }
}