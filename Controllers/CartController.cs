using AdrianWoronaProject91511.DAL;
using AdrianWoronaProject91511.Infrastructure;
using AdrianWoronaProject91511.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdrianWoronaProject91511.Controllers
{
    public class CartController : Controller
    {

        FilmsContext db;

        public CartController(FilmsContext db) 
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var cart = SessionManager.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey);

            ViewBag.totalPrice = cart.Sum(i => i.Quantity * i.Film.Price);
            return View(cart);
        }

        public IActionResult Buy(int id)
        {
            var film = db.Films.Find(id);
            if(SessionManager.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey) == null)
            {
                var cart = new List<CartItem>();
                cart.Add(new CartItem { Film = film, Quantity = 1, Value = film.Price});
                SessionManager.SetObjectAsJson(HttpContext.Session, Consts.CartSessionKey, cart);
            }
            else
            {
                var cart = SessionManager.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey);
                var index = GetIndex(id, cart);
                if (index == -1)
                {
                    cart.Add(new CartItem { Film = film, Quantity = 1, Value = film.Price });
                }
                else
                {
                    cart[index].Quantity++;
                    cart[index].Value+=film.Price;
                }
                SessionManager.SetObjectAsJson(HttpContext.Session, Consts.CartSessionKey, cart);
            }
            return RedirectToAction("Index");
        }

        int GetIndex(int id, List<CartItem> cart)
        {
            for(int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Film.Id == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
