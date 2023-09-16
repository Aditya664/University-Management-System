using System.ComponentModel.DataAnnotations;

namespace University_Management_System.Model.Domain
{
    public class Branch 
    {
        [Key]
        public string BranchName { get; set; }
    }
}
