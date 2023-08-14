using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notification.Models;
using System.Net;
using System.Net.Mail;
 
namespace Notification.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Notification.Models.gmail model)
		{
			MailMessage mm = new MailMessage("atn.system1@gmail.com", model.To);
			mm.Subject = model.Subject;
			mm.Body = model.Body;
			mm.IsBodyHtml = false;
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Port = 587;
			smtp.EnableSsl = true;

			NetworkCredential nc = new NetworkCredential("atn.system1@gmail.com", "G-475112");
			smtp.UseDefaultCredentials = true;
			smtp.Credentials = nc;
			smtp.Send(mm); 
            ViewBag.Message = "Mail has been sent successfully";

            return View();
        }
        
    }
}