using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using WhiteValley.ViewModels;


namespace WhiteValley.Controllers
{
    [RoutePrefix("contact"), Route("{action=index}")]
    public class ContactController : Controller
    {

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(ContactRequest postedModel)
        {
            if (!ModelState.IsValid)
                return View(postedModel);

            //the Captcha is a hidden field, if it is populated it suggests a bot so we disregard the request
            if (!String.IsNullOrEmpty(postedModel.Captcha))
                return View();


            var to = new MailAddress(ConfigurationManager.AppSettings["Mail.ContactToAddress"], "White Valley Contact");
            var from = new MailAddress(ConfigurationManager.AppSettings["Mail.ContactFromAddress"], "White Valley");
            var body = new StringBuilder();
            body.AppendLine("Name: " + postedModel.Name);
            body.AppendLine("Contact: " + postedModel.Contact);
            body.AppendLine("Message: " + postedModel.Message);

            var message = new MailMessage(from, to)
            {
                Subject = "White Valley website contact request",
                IsBodyHtml = false,
                Body = body.ToString(),
            };

            var smtp = new SmtpClient(ConfigurationManager.AppSettings["Mail.Host"])
            {
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Mail.Username"],
                        ConfigurationManager.AppSettings["Mail.Password"]),
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["Mail.Port"])
            };
            smtp.Send(message);

            return RedirectToAction("Sent");
        }


        [HttpGet]
        public ViewResult Sent()
        {
            return View();
        }


    }
}