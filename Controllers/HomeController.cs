﻿using AdrianWoronaProject91511.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdrianWoronaProject91511.Controllers
{
    public class HomeController : Controller
    {
        FilmsContext db;

        public HomeController(FilmsContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var kategorie = db.Categories.ToList();
            return View(kategorie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StronyStatyczne(string nazwaPodstrony)
        {
            return View(nazwaPodstrony);
        }
    }
}
