using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobsSystem.Models
{
    public class Job
    {
        public int id { get; set; }

        [Required(ErrorMessage = "This field required")]
        [StringLength(50)]
        public string title { get; set; }

        [Required(ErrorMessage = "This field required")]
        [StringLength(50)]
        public string description { get; set; }
        //public List<Application> Applications { get; set; }

        public List<Submission> Submissions { get; set; }

    }
}
