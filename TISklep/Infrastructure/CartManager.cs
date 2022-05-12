﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TISklep.DAL;
using TISklep.Models;

namespace TISklep.Infrastructure
{
    public static class CartManager
    {

        public static int RemoveFromCart(ISession session, int id)
        {
            var cart = GetItems(session);

            var thisFilm = cart.Find(i => i.Film.Id == id);

            int ilosc = 0;

            if (thisFilm == null)
            {
                return ilosc;
            }

            if (thisFilm.Ilosc > 1)
            {
                thisFilm.Ilosc--;
                ilosc = thisFilm.Ilosc;
            }
            else
            {
                cart.Remove(thisFilm);
            }

            SessionHelper.SetObjectasJson(session, Const.CartSessionKey, cart);

            return ilosc;
        }

        public static List<CartItem> GetItems(ISession session)
        {

            var cart = SessionHelper.GetObjecFromJson<List<CartItem>>(session, Const.CartSessionKey);

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;

        }

        public static decimal GetCartValue(ISession session)
        {
            var cart = GetItems(session);
            return cart.Sum(i => i.Ilosc * i.Film.Cena);
        }

        public static void AddToCart(ISession session, FilmyContext db, int id)
        {
            var cart = GetItems(session);
            var thisFilm = cart.Find(i => i.Film.Id == id);
            
            if(thisFilm != null)
            {
                thisFilm.Ilosc++;
            }
            else
            {
                var newCartItem = db.Filmy.Where(f => f.Id == id).SingleOrDefault();

                if(newCartItem != null)
                {
                    var cartItem = new CartItem()
                    {
                        Film = newCartItem,
                        Ilosc = 1,
                        Wartosc = newCartItem.Cena
                    };
                    cart.Add(cartItem);
                }
            }

            SessionHelper.SetObjectasJson(session, Const.CartSessionKey, cart);

        }
        public static int GetCartQuantity(ISession session)
        {
            var cart = GetItems(session);

            return cart.Sum(item => item.Ilosc);
        }

    }
}
