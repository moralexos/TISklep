using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TISklep.DAL;
using TISklep.ViewModels;

namespace TISklep.Controllers
{
    public class HomeController : Controller
    {
        FilmyContext db;

        public HomeController(FilmyContext db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {

            var vm = new IndexViewModel();

            vm.FilmyTopNajdluzsze = db.Filmy.OrderByDescending(x => x.DlugoscFilmu).Take(3).ToList();

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
    }
}
