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
            var listaJela = bazaPodataka.PopisJela.OrderBy(x => x.Naziv).ToList();
            ViewBag.Jela = listaJela;
            return View();        
        }

         [AllowAnonymous]
        public ActionResult PopisPartial(string naziv)
        {
            //System.Threading.Thread.Sleep(200); //simulacija duže obrade zahtjeva

            ViewBag.Naziv = naziv;
            var jela = bazaPodataka.PopisMeni.ToList();

            //filtriranje
            if (!String.IsNullOrWhiteSpace(naziv))
            {
                jela = jela.Where(x => x.NazivJelo.Naziv.ToUpper().Contains(naziv.ToUpper())).ToList();
            }
           

            return PartialView("_PartialPopis", jela);
        }

         public ActionResult Dodaj()
         {
            Meni jelo;
            jelo = new Meni();
            // JelaRepo listaJela = new JelaRepo(); 
            // var jela = new Tuple<IEnumerable<SelectListItem>>(listaJela.SvaJela());
            var listaJela = bazaPodataka.PopisJela.OrderBy(x => x.Naziv).ToList();
            
            ViewBag.Jela = listaJela;


            return View(jelo);
         }

        
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Dodaj(Meni j)
         {
             LogiraniKorisnik k = User as LogiraniKorisnik;
             if (k != null)
             {
                 ViewBag.Logirani = k.KorisnickoIme;
             }

            bazaPodataka.PopisMeni.Add(j);

            bazaPodataka.SaveChanges();

            return RedirectToAction("Popis");
         }

        [HttpGet]
        public JsonResult dohvatiCijenu(int jeloId)
        {
            decimal jeloCijena = bazaPodataka.PopisJela.SingleOrDefault(model => model.Id == jeloId).Cijena;
            return Json(jeloCijena, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Brisi(int? id)
        {
            //ako id nije defiran preusmjeravamo korisnika na popis studenata
            if (id == null)
            {
                return RedirectToAction("Popis");
            }

            //dohvaćamo studenta iz baze podataka na temelju id
            Meni m = bazaPodataka.PopisMeni.FirstOrDefault(x => x.Idmeni == id);

            //ako ne postoji student s tim id-em vraćamo HTTP status Not found
            if (m == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "Potvrda brisanja jela s menija";
            return View(m);
        }

        //Metoda za brisanje studenta
        //Poziva je metoda za potvrdu brisanja
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Brisi(int id)
        {
            Meni m = bazaPodataka.PopisMeni.FirstOrDefault(x => x.Idmeni == id);
            if (m == null)
            {
                return HttpNotFound();
            }

            bazaPodataka.PopisMeni.Remove(m);
            bazaPodataka.SaveChanges();

            //Ovdje smo definirali kao parametar naziv viewa koji metoda vraća
            //Pošto GET metoda Brisi vraća view Brisi ovdje putem parametra definiramo koji view vraća ova metoda
            //U tom viewu će biti prikazan status brisanja
            return View("BrisiStatus");
        }




    }
}