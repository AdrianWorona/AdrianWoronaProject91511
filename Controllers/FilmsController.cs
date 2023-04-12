using AdrianWoronaProject91511.DAL;
using AdrianWoronaProject91511.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace AdrianWoronaProject91511.Controllers
{
    public class FilmsController : Controller
    {
        FilmsContext db;
        IWebHostEnvironment env;

        public FilmsController(FilmsContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
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

        [HttpGet]
        public IActionResult AddFilm()
        {
            var model = new AddFilmViewModel();
            var categories = db.Categories.ToList();

            model.Categories = categories;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddFilm(AddFilmViewModel model)
        {
            var folderPath = Path.Combine(env.WebRootPath, "content");
            var posterPath = Path.Combine(folderPath, model.Poster.FileName);

            model.Poster.CopyTo(new FileStream(posterPath, FileMode.Create));

            model.NewFilm.PublishDate = DateTime.Now;

            model.NewFilm.PosterName = model.Poster.FileName;
            db.Films.Add(model.NewFilm);

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
