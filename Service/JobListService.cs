using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobListAPI.Model;
using JobListAPI.Repo;

namespace JobListAPI.Service
{
    public interface IJobListService
    {
        Task<IEnumerable<JobList>> GetJobLists();
        Task<JobList> GetJobById(long ID);
    }
    public class JobListService : IJobListService
    {
        private readonly IJobListRepo _jobListRepo;

        public JobListService(IJobListRepo jobListRepo)
        {
            _jobListRepo = jobListRepo;
        }

        public async Task<IEnumerable<JobList>> GetJobLists()
        {

            var joblists = await Task.Run(() => _jobListRepo.GetJobLists().ToList());

            return joblists;
        }

        public async Task<JobList> GetJobById(long ID)
        {
            var job = await Task.Run(() => _jobListRepo.GetJobLists().First(x => x.ID == ID));

            return job;
        }
    }
}
