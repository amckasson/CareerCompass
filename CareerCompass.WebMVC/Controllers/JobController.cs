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
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateJobService();

            if (service.CreateJob(model))
            {
                TempData["SaveResult"] = "The job was added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The job could not be added.");

            return View("model");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }


        private JobServices CreateJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobServices(userId);
            return service;
        }
    }
}