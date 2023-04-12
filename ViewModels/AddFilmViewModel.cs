using AdrianWoronaProject91511.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AdrianWoronaProject91511.ViewModels
{
    public class AddFilmViewModel
    {
        public Film NewFilm { get; set; }

        public List<Category> Categories { get; set; }

        public IFormFile Poster { get; set; }
    }
}
