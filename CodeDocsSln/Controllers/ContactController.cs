using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeDocsSln.Models;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEnquiry([Bind(Include="Name, Email, Comments")] Enquiry enquiry)
        {
            return View();//Needs to return thanks for your comments
        }
    }
}