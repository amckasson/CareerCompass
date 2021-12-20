using CareerCompass.Models.JobModels;
using CareerCompass.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerCompass.WebMVC.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobServices(userId);
            var model = service.GetJobs();

            return View(model);
        }

        //GET Method; Making request to get the Create View
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid)
            {
            return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobServices(userId);

            service.CreateJob(model);

            return RedirectToAction("Index");
        }

    }
}