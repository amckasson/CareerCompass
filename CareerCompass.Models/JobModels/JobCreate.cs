using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCompass.Models.JobModels
{
    public class JobCreate
    {
        [Required]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Notes")]
        public string JobNotes { get; set; }


    }
}
