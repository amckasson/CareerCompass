using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCompass.Models.JobModels
{
    public class JobListItem
    {
        public int JobId { get; set; }

        public string CompanyName { get; set; }

        public string JobTitle { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
