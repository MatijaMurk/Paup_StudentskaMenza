using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paup_StudentskaMenza.Models;

namespace Paup_StudentskaMenza.Controllers
{
    public class NarudzbaController : Controller
    {
        private BazaDbContext bp = new BazaDbContext();
        public ActionResult Index()
        {
            return View();
        }

        private int Postoji(int id)
        {
            List<Stavka> kosarica = (List<Stavka>)Session["kosarica"];
            for (int i = 0; i < kosarica.Count; i++)
                if (kosarica[i].Jelo.Id == id)
                    return i;
            return -1;
        }
        public ActionResult Izbrisi(int id)
        {
            int index = Postoji(id);
            List<Stavka> kosarica = (List<Stavka>)Session["kosarica"];
            kosarica.RemoveAt(index);
            Session["kosarica"] = kosarica;
            return View("Kosarica");
        }

        public ActionResult Naruci(int id)
        {
            if (Session["kosarica"] == null)
            {
                List<Stavka> kosarica = new List<Stavka>();
                kosarica.Add(new Stavka(bp.PopisJela.Find(id), 1));
                Session["kosarica"] = kosarica;
            }
            else
            {
                List<Stavka> kosarica = (List<Stavka>)Session["kosarica"];
                int index = Postoji(id);
                if (index == -1)
                    kosarica.Add(new Stavka(bp.PopisJela.Find(id), 1));
                else
                    kosarica[index].Kolicina++;
                Session["kosarica"] = kosarica;

            }
            return View("Kosarica");

        }
    }
}