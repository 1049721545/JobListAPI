using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobListAPI.Model;
using JobListAPI.Service;

namespace JobListAPI.Controllers
{
    [ApiController]
    [Route("api/joblists")]
    public class JobListController : Controller
    {
        private readonly IJobListService _jobListService;

        public JobListController(
            IJobListService jobListService)
        {
            _jobListService = jobListService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobList>>> GetJobLists([FromQuery] JobList p)
        {
            var joblists = await _jobListService.GetJobLists(p);

            return joblists.ToList();
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<JobList>> GetJobById(long Id)
        {
            var job = await _jobListService.GetJobById(Id);

            if (job == null)
            {
                return NotFound();
            }
            else
            {
                return job;
            }          
        }
    }
}