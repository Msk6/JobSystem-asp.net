using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobsSystem.Models
{
    public class Submission
    {
        public int id { get; set; }

        [Required(ErrorMessage ="This field required")]
        [StringLength(50)]
        public string name { get; set; }

        [Required(ErrorMessage = "This field required")]
        [StringLength(50)]
        public string major { get; set; }

        [Required(ErrorMessage = "This field required")]
        public string cvFile { get; set; }

        public int JobId { get; set; }
        public Job job { get; set; }
    }
}
