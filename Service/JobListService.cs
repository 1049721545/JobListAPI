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
        Task<IEnumerable<JobList>> GetJobs(JobFilter filter);
        Task<JobList> GetJob(int id);
        Task<JobList> CreateJob(JobList job);
        Task UpdateJob(int id, JobList job);
        Task DeleteJob(int id);
    }
    public class JobListService : IJobListService
    {
        private readonly IJobListRepo _jobListRepo;

        public JobListService(IJobListRepo jobListRepo)
        {
            _jobListRepo = jobListRepo;
        }

        public async Task<IEnumerable<JobList>> GetJobs(JobFilter filter)
        {

            var jobs = await _jobListRepo.GetJobs(filter);

            return jobs;
        }

        public async Task<JobList> GetJob(int id)
        {
            var job = await _jobListRepo.GetJob(id);
            return job;
        }

        public async Task<JobList> CreateJob(JobList job)
        {
            var res = await _jobListRepo.CreateJob(job);
            return res;
        }

        public async Task UpdateJob(int id, JobList job)
        {
            job.ID = id;
            await _jobListRepo.UpdateJob(job);
        }

        public async Task DeleteJob(int id)
        {
            await _jobListRepo.DeleteJob(id);
        }
    }
}