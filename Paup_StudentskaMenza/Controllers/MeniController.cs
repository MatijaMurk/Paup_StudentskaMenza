using Paup_StudentskaMenza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paup_StudentskaMenza.Controllers
{
    public class MeniController : Controller
    {
        // GET: Meni
        BazaDbContext bazaPodataka = new BazaDbContext();
        // GET: Studenti
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Početna stranica";
            ViewBag.Menza = "Studentska menza";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Popis()
        {
            var jelo = bazaPodataka.Jelo.ToList();

            return View(jelo);
        }

        
    }
}