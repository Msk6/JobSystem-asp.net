using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsSystem.Models
{
    public class Application
    {
        public int id { get; set; }
        public int SubmissionId { get; set; }
        public int JobId { get; set; }
        public Submission submission { get; set; }
        public Job job { get; set; }
    }
}
