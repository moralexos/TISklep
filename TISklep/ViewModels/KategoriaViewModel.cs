using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TISklep.Models;

namespace TISklep.ViewModels
{
    public class KategoriaViewModel
    {
        public Kategoria Kategoria { get; set; }
        
        public IEnumerable<Film> FilmyKategorii { get; set; }

        public IEnumerable<Film> FilmyTop3Najnowsze { get; set; }
    }
}
