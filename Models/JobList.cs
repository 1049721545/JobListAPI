using System.ComponentModel.DataAnnotations.Schema;

namespace JobListAPI.Models
{
    public class JobList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string Order { get; set; }
        public string Brand { get; set; }
        public string Batch { get; set; }
        public int Tinplate { get; set; }
        public int Rejection { get; set; }
        public int Good { get; set; }
        public int Bad { get; set; }
        public string Note { get; set; }
    }
}
