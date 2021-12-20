using CareerCompass.Data;
using CareerCompass.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCompass.Services
{
    public class JobServices
    {
        private readonly Guid _userId;
        
        public JobServices(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateJob(JobCreate model)
        {
            var entity =
                new Job()
                {
                    OwnerId = _userId,
                    CompanyName = model.CompanyName,
                    CompanyAddress = model.CompanyAddress,
                    JobTitle = model.JobTitle,
                    JobNotes = model.JobNotes,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Jobs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobId = e.JobId,
                                    CompanyName = e.CompanyName,
                                    JobTitle = e.JobTitle,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

    }
}
