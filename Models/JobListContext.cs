using Microsoft.EntityFrameworkCore;

namespace JobListAPI.Models
{
    public class JobListContext : DbContext
    {
        public JobListContext(DbContextOptions<JobListContext> options)
            : base(options)
        {
        }

        public DbSet<JobList> JobList { get; set; }
    }
}
