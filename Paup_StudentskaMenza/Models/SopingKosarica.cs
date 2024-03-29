﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paup_StudentskaMenza.Models
{
    public partial class SopingKosarica
    {
        BazaDbContext bp = new BazaDbContext();
        string SopingKosaricaId { get; set; }
        public const string CartSessionKey = "KosaricaId";
        public static SopingKosarica GetCart(HttpContextBase context)
        {
            var cart = new SopingKosarica();
            cart.SopingKosaricaId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static SopingKosarica GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Jela jelo)
        {
            // Get the matching cart and album instances
            var cartItem = bp.Kosarice.SingleOrDefault(
                c => c.KosaricaId == SopingKosaricaId
                && c.JeloId == jelo.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Kosarica
                {
                    JeloId = jelo.Id,
                    KosaricaId = SopingKosaricaId,
                    Broj = 1,
                    KreiranoDatuma = DateTime.Now
                };
                bp.Kosarice.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Broj++;
            }
            // Save changes
            bp.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = bp.Kosarice.Single(
                cart => cart.KosaricaId == SopingKosaricaId
                && cart.StavkaId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Broj > 1)
                {
                    cartItem.Broj--;
                    itemCount = cartItem.Broj;
                }
                else
                {
                    bp.Kosarice.Remove(cartItem);
                }
                // Save changes
                bp.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = bp.Kosarice.Where(
                cart => cart.KosaricaId == SopingKosaricaId);

            foreach (var cartItem in cartItems)
            {
                bp.Kosarice.Remove(cartItem);
            }
            // Save changes
            bp.SaveChanges();
        }
        public List<Kosarica> GetCartItems()
        {
            return bp.Kosarice.Where(
                cart => cart.KosaricaId == SopingKosaricaId).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in bp.Kosarice
                          where cartItems.KosaricaId == SopingKosaricaId
                          select (int?)cartItems.Broj).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in bp.Kosarice
                              where cartItems.KosaricaId == SopingKosaricaId
                              select (int?)cartItems.Broj *
                              cartItems.Jelo.Cijena).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Narudzba narudzba)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                    var orderDetail = new DetaljiNarudzbe
                    {
                        JeloId = item.JeloId,
                        NarudzbaId = narudzba.NarudzbaId,
                        Cijena = item.Jelo.Cijena,
                        Kolicina = item.Broj
                    };
                // Set the order total of the shopping cart
                orderTotal += (item.Broj * item.Jelo.Cijena);

                bp.PopisDetaljaNarudzbe.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            narudzba.Total = orderTotal;

            // Save the order
            bp.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return narudzba.NarudzbaId;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
       
    }
}