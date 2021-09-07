using Paup_StudentskaMenza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paup_StudentskaMenza.Misc;
using System.Net;

namespace Paup_StudentskaMenza.Controllers
{
    public class JelaController : BaseController
    {
        // GET: Meni
        private BazaDbContext bazaPodataka = new BazaDbContext();


        // GET: Studenti
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Početna stranica";
            ViewBag.Menza = "Studentska menza";
           
            return View(bazaPodataka.Jelo.ToList());
        }



        [AllowAnonymous]

        public ActionResult Azuriraj(int? id)
        {

            Jela jelo;
            
            if (!id.HasValue)
            {
                jelo = new Jela();
                ViewBag.Title = "Kreiranje jela";
                ViewBag.Novi = true;
            }
            //ako id postoji onda provjeravamo ako taj student postoji u bazi podataka
            else
            {
                jelo = bazaPodataka.Jelo.FirstOrDefault(x => x.Id == id);

                //ako u listi nema studenta sa traženim Id-em onda je objekt student null
                if (jelo == null)
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                    //Ili skraćeno
                    return HttpNotFound();
                }

                ViewBag.Title = "Ažuriranje jela";
                ViewBag.Novi = false;

            }
           
            var ovlast = bazaPodataka.PopisOvlasti.OrderBy(x => x.Naziv).ToList();
            ViewBag.Ovlast = ovlast;
            //var status = bazaPodataka.PopisStatusa.OrderBy(x => x.id).ToList();
            //ViewBag.Status = status;

            return View(jelo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(Jela jelo)
        {
            /*LogiraniKorisnik k = User as LogiraniKorisnik;
            if (k != null)
            {
                ViewBag.Logirani = k.KorisnickoIme;
            }*/

            if (ModelState.IsValid)
            {
                //ako model ima vrijednost parametra Id različito od 0 tada znamo da korisnik ažurira podatke o studentu
                if (jelo.Id != 0)
                {
                    bazaPodataka.Entry(jelo).State = System.Data.Entity.EntityState.Modified;
                }
                //ako model ima vrijednost parametra Id jednak 0 tada se radi o dodavanju novog studenta
                else
                {
                    bazaPodataka.Jelo.Add(jelo);
                }
                bazaPodataka.SaveChanges();
                return RedirectToAction("Index");
            }

            if (jelo.Id == 0)
            {
                ViewBag.Title = "Kreiranje jela";
                ViewBag.Novi = true;
            }
            else
            {
                ViewBag.Title = "Ažuriranje jela";
                ViewBag.Novi = false;
            }
            return View(jelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Opis,Cijena,Vegetarijansko")] Jela jelo)
        {
            if (ModelState.IsValid)
            {
                bazaPodataka.Jelo.Add(jelo);
                bazaPodataka.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jelo);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Popis");
            }

            //dohvaćamo studenta iz baze podataka na temelju id
            Jela jelo = bazaPodataka.Jelo.FirstOrDefault(x => x.Id == id);

            //ako ne postoji student s tim id-em vraćamo HTTP status Not found
            if (jelo == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "Potvrda brisanja studenta";
            return View(jelo);
        }

        // POST: Smjerovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jela jelo = bazaPodataka.Jelo.Find(id);
            bazaPodataka.Jelo.Remove(jelo);
            bazaPodataka.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bazaPodataka.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}