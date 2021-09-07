using Paup_StudentskaMenza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paup_StudentskaMenza.Misc;


namespace Paup_StudentskaMenza.Controllers
{
    public class MeniController : BaseController
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

       /* public ActionResult Azuriraj(int? id)
        {
            Meni jelo;
            jelo = bazaPodataka.Jelo.FirstOrDefault(x => x.Id == id);
            if (jelo == null)
            {
                return HttpNotFound();
            }
            var ovlast = bazaPodataka.PopisOvlasti.OrderBy(x => x.Naziv).ToList();
            ViewBag.Ovlast = ovlast;
            //var status = bazaPodataka.PopisStatusa.OrderBy(x => x.id).ToList();
            //ViewBag.Status = status;

            return View(jelo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(Meni jelo)
        {
            LogiraniKorisnik k = User as LogiraniKorisnik;
            if (k != null)
            {
                ViewBag.Logirani = k.KorisnickoIme;
            }
            if (jelo.Id != 0)
            {
                bazaPodataka.Entry(jelo).State = System.Data.Entity.EntityState.Modified;
            }
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated && ((User as LogiraniKorisnik).IsInRole(OvlastiKorisnik.Administrator)))
                {
                    jelo.Naziv = jelo.Naziv;
                }
               
                bazaPodataka.SaveChanges();
                return RedirectToAction("Popis");
            }
            return View(jelo);
        }*/


    }
}