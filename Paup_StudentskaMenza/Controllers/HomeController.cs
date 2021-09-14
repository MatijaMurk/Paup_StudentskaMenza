using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Paup_StudentskaMenza.Misc;
using Paup_StudentskaMenza.Models;

namespace Paup_StudentskaMenza.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            LogiraniKorisnik logkor = User as LogiraniKorisnik;
            if(logkor !=null)
            {
                ViewBag.Logirani = logkor.KorisnickoIme;

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(Mail e)
        {
            LogiraniKorisnik k = User as LogiraniKorisnik;
            using (MailMessage mm = new MailMessage(k.Email, "testnimail555@gmail.com"))
            {
                mm.Subject = "Zahtjev za jelo";
                mm.Body = e.Poruka;
                /*if (model.Attachment.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(model.Attachment.FileName);
                    mm.Attachments.Add(new Attachment(model.Attachment.InputStream, fileName));
                }*/
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(k.Email, "loznika123");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    ViewBag.Message = "Poruka poslana.";
                }
            }
           
            return View();
        }

      
    }
}