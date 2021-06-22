using SATProject.Models;
using System.Web.Mvc;
using System.Net.Mail;
using System;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }
            //Do stuff here
            string message = $"You have received an email from {cvm.Name}. Please respond to {cvm.Email} with your response to the following message: <br/>{cvm.Message}";
            string subject = "New contact form submission";

            MailMessage mm = new MailMessage("admin@tim-lopez.com", "tlopez82@hotmail.com", subject, message);



            //MailMessage Properties
            //Allow Html formatting in the email (message has HTML in it)
            mm.IsBodyHtml = true;

            //If you want to set high priority on these messages, place the following
            mm.Priority = MailPriority.High;

            //Respond to the sender's email rather than our own SMTP Client (webmail)
            mm.ReplyToList.Add(cvm.Email);

            //Assemble the SMTPClient object - This is the information from the Host (smarterASP.net). This allows the message to actually be sent.
            SmtpClient client = new SmtpClient("mail.tim-lopez.com");

            //Client credentials (username and password for the email user you set up in the host
            client.Credentials = new System.Net.NetworkCredential("admin@tim-lopez.com", "Aliyah01!");

            try
            {
                client.Send(mm);
            }
            catch (Exception ex)
            {
                ViewBag.CustomerMessage = $"We're sorry your request could not be completed at this time. Please try again later.<br/>Error Message:<br/>{ex.StackTrace}";
                return View(cvm);

                //return the view WITH the entire message so that users can copy/paste later

            }
            //If all goes well and the message is sent, return a separate view that displays a receipt of their inputs

            return View("Thank You", cvm);
        }
    }
}
