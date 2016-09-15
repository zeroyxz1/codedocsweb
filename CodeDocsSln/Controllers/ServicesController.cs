using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeDocsSln.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult FirstSteps()
        {
            ViewBag.Message = "Contact CodeDocs regarding how your business can take advantage of the Cloud.";

            return View();
        }

        public ActionResult NextSteps()
        {
            ViewBag.Message = "Contact CodeDocs regarding how your business can take advantage of the Cloud.";

            return View();
        }

        public ActionResult Optimise()
        {
            ViewBag.Message = "Contact CodeDocs regarding how your business can take advantage of the Cloud.";

            return View();
        }

        public ActionResult Development()
        {
            ViewBag.Message = "Contact CodeDocs regarding how your business can take advantage of the Cloud.";

            return View();
        }

        public ActionResult Consult()
        {
            ViewBag.Message = "Contact CodeDocs regarding how your business can take advantage of the Cloud.";

            return View();
        }
    }
}