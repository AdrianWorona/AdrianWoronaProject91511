using AdrianWoronaProject91511.DAL;
using AdrianWoronaProject91511.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdrianWoronaProject91511.Controllers
{
    public class FilmsController : Controller
    {
        FilmsContext db;

        public FilmsController(FilmsContext db)
        {
            this.db = db;
        }

        public IActionResult FilmsList(string categoryName)
        {
            var model = new CategoryFilmsViewModel();

            var category = db.Categories.Include("Films").Where(c => c.Name.ToUpper() == categoryName.ToUpper()).Single();

            var films = category.Films.ToList();

            model.CategoryFilms = films;
            model.RecentFilms = db.Films.OrderByDescending(f => f.PublishDate).Take(3);
            model.Category = category;

            return View(model);
        }

        public IActionResult Details(int filmId)
        {
            //var category = db.Categories.Find(db.Films.Find(filmId).CategoryId);
            //var film = db.Films.Find(filmId);

            var film = db.Films.Include("Category").Where(f => f.Id == filmId).Single();
            return View(film);
        }
    }
}
