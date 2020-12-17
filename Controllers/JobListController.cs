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
    public class JobListController : Controller
    {

        private readonly IJobListService _jobListService;

        public JobListController(
            IJobListService joblistService)
        {
            _jobListService = joblistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobList>>> GetJobLists()
        {
            var joblists = await _jobListService.GetJobLists();

            return joblists.ToList();
        }
    }
}