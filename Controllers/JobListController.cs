using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobListAPI.Models;

namespace JobListAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobListController : ControllerBase
    {
        private readonly JobListContext _context;
        public JobListController(JobListContext context)
        {
            _context = context;
        }

        public IQueryable<JobList> JobListQuery(string searchString)
        {
            var joblist = from r in _context.JobList
                            select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                joblist = joblist.Where(r => r.Order.Contains(searchString)
                                            || r.Batch.Contains(searchString)
                                            || r.Brand.Contains(searchString));
            }
            return joblist;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobList>>> GetJobList()
        {
            return await _context.JobList.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobList>> GetJobList(long id)
        {
            var joblist = await _context.JobList.FindAsync(id);

            if (joblist == null)
            {
                return NotFound();
            }

            return joblist;
        }
    }
}
