using AdrianWoronaProject91511.DAL;
using AdrianWoronaProject91511.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdrianWoronaProject91511.Infrastructure
{
    public static class CartManager
    {
        public static int RemoveFromCart(ISession session, int id)
        {
            var cart = GetItems(session);
            var thisFilm = cart.Find(i=>i.Film.Id == id);
            var quantity = 0;
            if (thisFilm == null) return 0;

            if(thisFilm.Quantity > 1)
            {
                thisFilm.Quantity--;
                thisFilm.Value -= thisFilm.Film.Price;
                quantity = thisFilm.Quantity;
            }
            else
            {
                cart.Remove(thisFilm);
            }

            session.SetObjectAsJson(Consts.CartSessionKey, cart);
            return quantity;
        }

        internal static decimal? GetCartValue(ISession session)
        {
            var cart = GetItems(session);
            return cart.Sum(i => i.Value);
        }

        internal static decimal? GetItemValue(ISession session, int id)
        {
            var cart = GetItems(session);
            foreach(var item in cart)
            {
                if(id == item.Film.Id)
                {
                    return item.Value;
                    //return cart.Sum(f => f.Value);
                }
            }
            return 0;
        }

        public static List<CartItem> GetItems(ISession session)
        {
            var cart = SessionManager.GetObjectFromJson<List<CartItem>>(session, Consts.CartSessionKey);

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public static void AddToCart(ISession session, FilmsContext db, int filmId)
        {
            var cart = GetItems(session);
            var thisfilm = cart.Find( f => f.Film.Id == filmId);

            if(thisfilm != null)
            {
                thisfilm.Quantity++;
                thisfilm.Value += thisfilm.Film.Price;
            }
            else
            {
                var newCartItem = db.Films.Where(id =>  id.Id == filmId).SingleOrDefault();

                if(newCartItem != null)
                {
                    var cartItem = new CartItem
                    {
                        Film = newCartItem,
                        Quantity = 1,
                        Value = newCartItem.Price
                    };
                    cart.Add(cartItem);
                }
            }
            SessionManager.SetObjectAsJson(session, Consts.CartSessionKey, cart);
        }
    }
}
