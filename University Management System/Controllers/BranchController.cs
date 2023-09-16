using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Management_System.Data;
using University_Management_System.Model.Domain;

namespace University_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly BranchRepository _branchRepository;

        public BranchController(BranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        [HttpGet]
        public IActionResult GetAllBranch()
        {
            return Ok(_branchRepository.GetBranches());
        }

        [HttpGet("{branchName}")]
        public IActionResult GetBranch(string branchName) 
        {
            var branch = _branchRepository.GetBranch(branchName);
            if(branch == null) 
            {
                return NotFound();
            }
            return Ok(branch);
        }

        [HttpDelete]
        public IActionResult DeleteBranch(string branchName)
        {
            var branch = _branchRepository.RemoveBranch(branchName);
            if (branch == null)
            {
                return NotFound();
            }
            return Ok(branch);
        }

        [HttpPost]
        public IActionResult AddBranch(Branch branch)
        {
            _branchRepository.AddBranch(branch);
            return CreatedAtAction(nameof(GetBranch),new { branchName = branch.BranchName }, branch);
        }
    }
}
