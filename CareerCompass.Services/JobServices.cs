using CareerCompass.Data;
using CareerCompass.Models;
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

        public JobDetail GetJobById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == id && e.OwnerId == _userId);
                return
                    new JobDetail
                    {
                        JobId = entity.JobId,
                        CompanyName = entity.CompanyName,
                        JobTitle = entity.JobTitle,
                        CompanyAddress = entity.CompanyAddress,
                        JobNotes = entity.JobNotes,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }

        public bool UpdateJob(JobEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs.Single(e => e.JobId == model.JobId && e.OwnerId == _userId);

                entity.CompanyName = model.CompanyName;
                entity.CompanyAddress = model.CompanyAddress;
                entity.JobTitle = model.JobTitle;
                entity.JobNotes = model.JobNotes;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;

            }
        }

    }
}
