using University_Management_System.Model.Domain;

namespace University_Management_System.Data
{
    public class BranchRepository
    {
        private readonly UniversityDbContext _context;

        public BranchRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public List<Branch> GetBranches()
        {
            return _context.Branches.ToList();
        }

        public Branch GetBranch(string branchName)
        {
            var branch = _context.Branches.FirstOrDefault(x => x.BranchName == branchName);
            if (branch == null)
            {
                return null;
            }
            return branch;
        }

        public Branch AddBranch(Branch branch)
        {
            _context.Branches.Add(branch);  
            _context.SaveChanges();
            return branch;
        }

        public Branch RemoveBranch(string branchName)
        {
            var branch = GetBranch(branchName);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
                _context.SaveChanges();
                return branch;
            }
            return null;
        }
    }
}
