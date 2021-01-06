using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobListAPI.Model;
using JobListAPI.Service;

namespace JobListAPI.Controllers
{
    [ApiController]
    [Route("api/joblists")]
    public class JobController : Controller
    {

        private readonly IJobListService _jobListService;

        public JobController(
            IJobListService jobListService)
        {
            _jobListService = jobListService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobList>>> GetJobs()
        {
            _ = DateTime.TryParse(HttpContext.Request.Query["postedon"].ToString(), out DateTime postedOn);

            var filter = new JobFilter
            {
                IsActive = HttpContext.Request.Query["isactive"].ToString() == "true",
                PostedOn = postedOn,
                Title = HttpContext.Request.Query["title"].ToString()
            };
                
            var jobs = await _jobListService.GetJobs(filter);

            return jobs.ToList();
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<JobList>> GetJob(int id)
        {
            var job = await _jobListService.GetJob(id);

            return job;
        }

        [HttpPost]

        public async Task<ActionResult<JobList>> PostJob(JobList job)
        {
            var response = await _jobListService.CreateJob(job);

            return response;
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<ActionResult> PutJob(int id, JobList job)
        {
            await _jobListService.UpdateJob(id, job);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult> DeleteJob(int id)
        {
            await _jobListService.DeleteJob(id);

            return NoContent();
        }
    }
}
