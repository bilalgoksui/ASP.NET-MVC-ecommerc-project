using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using(CompanyEntities1 db = new CompanyEntities1())
            {
                var model = db.Logss.ToList();
                return View(model);
            }
            
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\faren\source\repos\FinalProject\css\about.css");
            string fileName = "about.css";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            bool isUploadSuccessful = false;
            if (file != null && file.ContentLength > 0)
            {
                // get the file name
                var fileName = Path.GetFileName(file.FileName);

                // set where you want to store files
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

                // save the file
                file.SaveAs(path);
                isUploadSuccessful = true;
            }
            ViewBag.IsUploadSuccessful = isUploadSuccessful;
            if (isUploadSuccessful)
                ViewBag.UploadMessage = "File Upload Successful";
            else
                ViewBag.UploadMessage = "File Upload Failed";

            return View();
        }
    }
}