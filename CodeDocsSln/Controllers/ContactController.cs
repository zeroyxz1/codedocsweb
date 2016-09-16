using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeDocsSln.Models;
using CodeDocsSln.DataAccess;
using CodeDocsSln.ViewModels;

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

        [HttpGet]
        public ActionResult Enquiry()
        {
            ViewBag.Message = "Contact CodeDocs regarding how your business can take advantage of the Cloud.";

            //Create an instance of the viewmodel and return it to the view
            CreateEnquiryViewModel vm = new CreateEnquiryViewModel();
            return View(vm);
        }

        public ActionResult EnquiryResponse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enquiry([Bind(Include="Name, Email, Comments")] Enquiry enquiry)
        {
            try
            {
                enquiry.Id = Guid.NewGuid();
                enquiry.SubmittedOn = DateTime.Now;

                CodeDocsSln.DataAccess.DataStore ds = new DataStore();
                ds.Save(enquiry);

                ViewBag.SavedEnquiry = true;
            }

            catch (Exception ex)
            {
                //TODO::Write this somewhere we can investigate later
                ViewBag.SavedEnquiry = false;
            }


            return View("EnquiryResponse");//Needs to return thanks for your comments
        }
    }
}