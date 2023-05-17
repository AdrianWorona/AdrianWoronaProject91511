using AdrianWoronaProject91511.DAL;
using AdrianWoronaProject91511.Infrastructure;
using AdrianWoronaProject91511.Models;
using AdrianWoronaProject91511.ViewModels;
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

        [Route("Koszyk")]
        public IActionResult Index()
        {
            var cart = CartManager.GetItems(HttpContext.Session);

            //if(cart == null)
            //{
            //    cart = new List<CartItem>();
            //}
            ViewBag.totalPrice = CartManager.GetCartValue(HttpContext.Session);
            return View(cart);
        }

        public IActionResult Buy(int id)
        {
            CartManager.AddToCart(HttpContext.Session, db, id);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var model = new ItemRemoveViewModel()
            {
                ItemId = id,
                ItemQuantity = CartManager.RemoveFromCart(HttpContext.Session, id),
                TotalValue = CartManager.GetCartValue(HttpContext.Session),
                ItemValue = CartManager.GetItemValue(HttpContext.Session, id)
            };

            return Json(model);

        }
    }
}
