using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeDocsSln.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact CodeDocs regarding how your business can take advantage of the Cloud.";

            return View();
        }

        public ActionResult Enquiry()
        {
            ViewBag.Message = "Contact CodeDocs regarding how your business can take advantage of the Cloud.";

            return View();
        }
    }
}