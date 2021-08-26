using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paup_StudentskaMenza.Misc;

namespace Paup_StudentskaMenza.Controllers
{
    public class HomeController : Controller
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
    }
}