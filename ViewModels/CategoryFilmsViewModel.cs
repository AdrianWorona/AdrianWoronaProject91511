using AdrianWoronaProject91511.Models;
using System.Collections;
using System.Collections.Generic;

namespace AdrianWoronaProject91511.ViewModels
{
    public class CategoryFilmsViewModel
    {
        public  IEnumerable<Film> CategoryFilms { get; set; }
        public IEnumerable<Film> RecentFilms { get; set; }

        public Category Category { get; set; }
    }
}
