using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCompass.Models.JobModels
{
    public class JobEdit
    {
        public int JobId { get; set; }

        public string CompanyName { get; set; }

        public string JobTitle { get; set; }

        public string CompanyAddress { get; set; }

        public string JobNotes { get; set; }
    }
}
