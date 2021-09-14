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
            return View(bazaPodataka.Jelo.ToList());        
        }

         public ActionResult Dodaj(int? dan)
         {
            JelaRepo listaJela = new JelaRepo(); 
             var jela = new Tuple<IEnumerable<SelectListItem>>(listaJela.SvaJela());


             return View(jela);
         }

        
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Dodaj(Jela jelo)
         {
             LogiraniKorisnik k = User as LogiraniKorisnik;
             if (k != null)
             {
                 ViewBag.Logirani = k.KorisnickoIme;
             }
            
                 return RedirectToAction("Popis");
             }

        [HttpGet]
        public JsonResult dohvatiCijenu(int jeloId)
        {
            decimal jeloCijena = bazaPodataka.Jelo.SingleOrDefault(model => model.Id == jeloId).Cijena;
            return Json(jeloCijena, JsonRequestBehavior.AllowGet);
        }
     



    }
}