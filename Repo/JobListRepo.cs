using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobListAPI.Model;

namespace JobListAPI.Repo
{
    
    public interface IJobListRepo
    {
        Task<IEnumerable<JobList>> GetJobs(JobFilter filter);
        Task<IEnumerable<JobList>> GetJobsByTitle(string title);
        Task<JobList> GetJob(int id);
        Task<JobList> CreateJob(JobList job);
        Task UpdateJob(JobList job);
        Task DeleteJob(int id);
    }

    public class JobListRepo : IJobListRepo
    {
        private readonly JobListDbContext _jobListDbContext;
        public JobListRepo(JobListDbContext jobListDbContext) {
            _jobListDbContext = jobListDbContext;
        }

        public async Task<IEnumerable<JobList>> GetJobs(JobFilter filter)
        {
            var query =  _jobListDbContext.JobLists
                .Where(j => j.IsActive == filter.IsActive);

            if (filter.PostedOn != default)
            {
                query.Where(j => j.PostedOn > filter.PostedOn);
            }

            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                query.Where(j => j.Title.Contains(filter.Title));
            }

            var jobs = await query.ToListAsync();

            return jobs;
        }

        public async Task<IEnumerable<JobList>> GetJobsByTitle(string title)
        {
            var jobs = await _jobListDbContext.JobLists
                .Where(j => j.Title.Contains(title) && j.IsActive == true)
                .ToListAsync();

            return jobs;
        }

        public async Task<JobList> GetJob(int id)
        {
            var job = await _jobListDbContext.JobLists.FindAsync(id);

            return job;
        }

        public async Task<JobList> CreateJob(JobList job)
        {
            _jobListDbContext.JobLists.Add(job);
            
            await _jobListDbContext.SaveChangesAsync();

            return job;
        }

        public async Task UpdateJob(JobList job)
        {
            _jobListDbContext.Entry(job).State = EntityState.Modified;
            await _jobListDbContext.SaveChangesAsync();
        }

        public async Task DeleteJob(int id)
        {
            var job = await GetJob(id);

            _jobListDbContext.Remove(job);
            await _jobListDbContext.SaveChangesAsync();
        }
    }
}
