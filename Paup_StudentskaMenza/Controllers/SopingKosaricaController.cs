using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paup_StudentskaMenza.Models;
using Paup_StudentskaMenza.ViewModels;

namespace Paup_StudentskaMenza.Controllers
{
    public class SopingKosaricaController : BaseController
    {
        // GET: SopingKosarica
        BazaDbContext storeDB = new BazaDbContext();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = SopingKosarica.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new SopingKosaricaViewModel
            {
                CartItems = cart.GetCartItems(),
                KosaricaUkupno = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var dodanoJelo = storeDB.PopisJela
                .Single(jelo => jelo.Id == id);

            // Add it to the shopping cart
            var cart = SopingKosarica.GetCart(this.HttpContext);

            cart.AddToCart(dodanoJelo);

            // Go back to the main store page for more shopping
            return RedirectToAction("Popis","Meni");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = SopingKosarica.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string nazivJela = storeDB.Kosarice
                .Single(item => item.StavkaId == id).Jelo.Naziv;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new UkloniKosaricuViewModel
            {
                Message = Server.HtmlEncode(nazivJela) +
                    " je uklonjeno iz vaše košarice",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = SopingKosarica.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}