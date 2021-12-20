using CareerCompass.Models.JobModels;
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
            var model = new JobListItem[0];
            return View(model);
        }
    }
}