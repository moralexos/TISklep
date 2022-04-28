using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TISklep.DAL;
using TISklep.Infrastructure;
using TISklep.Models;

namespace TISklep.Controllers
{
    public class KoszykController : Controller
    {
        FilmyContext db;

        public KoszykController(FilmyContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjecFromJson<List<CartItem>>(HttpContext.Session, Const.CartSessionKey);

            if(cart == null)
            {
                cart = new List<CartItem>();
            }
            
            ViewBag.total = cart.Sum(item => item.Ilosc * item.Film.Cena);

            return View(cart);
        }

        public IActionResult DodajDoKoszyka(int IdFilmu)
        {
            var film = db.Filmy.Find(IdFilmu);

            if (SessionHelper.GetObjecFromJson<List<CartItem>>(HttpContext.Session, Const.CartSessionKey) == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem()
                {
                    Film = film,
                    Ilosc = 1,
                    Wartosc = (decimal)film.Cena
                });

                SessionHelper.SetObjectasJson(HttpContext.Session, Const.CartSessionKey, cart);
            }
            else
            {
                List<CartItem> cart = SessionHelper.GetObjecFromJson<List<CartItem>>(HttpContext.Session, Const.CartSessionKey);


                int index = GetIndex(IdFilmu);

                if(index != -1)
                {
                    cart[index].Ilosc++;
                }
                else
                {
                    cart.Add(new CartItem()
                    {
                        Film = film,
                        Ilosc = 1,
                        Wartosc = (decimal)film.Cena
                    });
                }
                SessionHelper.SetObjectasJson(HttpContext.Session, Const.CartSessionKey, cart);
            }

            return RedirectToAction("Index");
        }

        private int GetIndex(int idFilmu)
        {
            var cart = SessionHelper.GetObjecFromJson<List<CartItem>>(HttpContext.Session, Const.CartSessionKey);

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Film.Id.Equals(idFilmu))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
