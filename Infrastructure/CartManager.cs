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

        internal static decimal GetItemValue(ISession session, int id)
        {
            throw new NotImplementedException();
        }

        private static List<CartItem> GetItems(ISession session)
        {
            var cart = SessionManager.GetObjectFromJson<List<CartItem>>(session, Consts.CartSessionKey);

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }
    }
}
