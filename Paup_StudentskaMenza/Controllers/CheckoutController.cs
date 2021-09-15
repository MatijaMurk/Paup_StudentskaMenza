using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paup_StudentskaMenza.Models;

namespace Paup_StudentskaMenza.Controllers
{
    [Authorize]
    public class CheckoutController : BaseController
    {
        BazaDbContext bp = new BazaDbContext();
        const string PromoKod = "FREE";


        public ActionResult Placanje()
        {
            return View();
        }
        // GET: Checkout
        [HttpPost]
        public ActionResult Placanje(FormCollection vrijednosti)
        {
            var narudzba = new Narudzba();



           TryUpdateModel(narudzba);
            try
            {
                if(string.Equals(vrijednosti["PromoKod"],PromoKod,StringComparison.OrdinalIgnoreCase)==false)
                {
                    return View(narudzba);

                }
                else
                {
                    narudzba.Korisnik = User.Identity.Name;
                    narudzba.DatumNarudzbe = DateTime.Now;

                    bp.PopisNarudzba.Add(narudzba);
                    bp.SaveChanges();
                    var kosarica = SopingKosarica.GetCart(this.HttpContext);
                    kosarica.CreateOrder(narudzba);

                    return RedirectToAction("Izvrseno", new { id = narudzba.NarudzbaId });

                }
            }
            catch
            {
                return View(narudzba);
            }
           
        }

        public ActionResult Izvrseno(int id)
        {
            bool isValid = bp.PopisNarudzba.Any(n => n.NarudzbaId == id && n.Korisnik == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}