﻿using AdrianWoronaProject91511.Models;
using Microsoft.EntityFrameworkCore;

namespace AdrianWoronaProject91511.DAL
{
    public class FilmsContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public FilmsContext(DbContextOptions<FilmsContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() 
                { 
                    Id = 1, 
                    Name = "Horror", 
                    Description = "Straszne filmy"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Dokumentalne",
                    Description = "Filmy oparte na faktach"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Thriller",
                    Description = "Dreszczowce"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Sensacyjne",
                    Description = "Filmy z akcją"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Fantasy",
                    Description = "Filmy z elementami nadprzyrodzonymi i magicznymi"
                }
                );

            modelBuilder.Entity<Film>().HasData(
                  new Film()
                  {
                      Id = 1,
                      CategoryId = 1,
                      Title = "Teksańska Masakra Piłą Mechaniczną",
                      Director = "Marcus Nispel",
                      Desc = "20 sierpnia 1973 roku teksańska policja trafiła do stojącego na uboczu domu Thomasa Hewitta - byłego pracownika lokalnej rzeźni. Na miejscu odkryli rozkładające się zwłoki 33 osób, które zostały zamordowane przez psychopatycznego zabójcę noszącego na twarzy maskę z ludzkiej skóry i posługującego się piłą mechaniczną.",
                      Price = 10m,
                      PublishDate = new System.DateTime(2022, 12, 10),
                      PosterName = "teksanska-masakra-pila-mechaniczna.jpg"
                  },
                new Film()
                {
                    Id = 2,
                    CategoryId = 3,
                    Title = "Numer 23",
                    Director = "Joel Schumacher",
                    Desc = "Mężczyzna dostaje obsesji na punkcie książki, która według niego Descuje i przewiduje jego życie i przyszłość.",
                    Price = 14m,
                    PublishDate = new System.DateTime(2022, 11, 15),
                    PosterName = "numer-23.jpg"
                },
                new Film()
                {
                    Id = 3,
                    CategoryId = 3,
                    Title = "Sekretne Okno",
                    Director = "David Koepp",
                    Desc = "Uznany pisarz przenosi się na prowincję, by w spokoju tworzyć kolejne książki. Wkrótce odwiedzi go tajemniczy mężczyzna, który oskarży Raineya o plagiat.",
                    Price = 12m,
                    PublishDate = new System.DateTime(2023, 01, 21),
                    PosterName = "sekretne-okno.jpg"
                },
                new Film()
                {
                    Id = 4,
                    CategoryId = 5,
                    Title = "Władca Pierścieni: Drużyna Pierścienia",
                    Director = "Peter Jackson",
                    Desc = "Podróż hobbita z Shire i jego ośmiu towarzyszy, której celem jest zniszczenie potężnego pierścienia pożądanego przez Czarnego Władcę - Saurona.",
                    Price = 20m,
                    PublishDate = new System.DateTime(2023, 03, 10),
                    PosterName = "wladca-pierscieni-druzyna-pierscienia.jpg"
                },
                new Film()
                {
                    Id = 5,
                    CategoryId = 4,
                    Title = "Red",
                    Director = "Robert Schwentke",
                    Desc = "Emerytowani agenci specjalni CIA zostają wrobieni w zamach. By się ratować, muszą reaktywować stary zespół.",
                    Price = 11m,
                    PublishDate = new System.DateTime(2022, 07, 18),
                    PosterName = "red.jpg"
                },
                new Film()
                {
                    Id = 6,
                    CategoryId = 2,
                    Title = "Tylko nie mów nikomu",
                    Director = "Tomasz Sekielski",
                    Desc = "Dziennikarz śledczy rozmawia z dziewięcioma księżmi katolickimi, którzy dopuścili się zbrodni pedofilii i molestowania nieletnich, a także ich ofiarami.",
                    Price = 0m,
                    PublishDate = new System.DateTime(2022, 05, 06),
                    PosterName = "tylko-nie-mow-nikomu.jpg"
                },
                new Film()
                {
                    Id = 7,
                    CategoryId = 5,
                    Title = "Iluzjonista",
                    Director = "Neil Burger",
                    Desc = "Wiedeń u progu XX w. Syn rzemieślnika, iluzjonista Eisenheim, wykorzystuje niezwykłe umiejętności, by zdobyć miłość arystokratki, narzeczonej austro-węgierskiego księcia.",
                    Price = 13m,
                    PublishDate = new System.DateTime(2023, 02, 05),
                    PosterName = "iluzjonista.jpg"
                },
                new Film()
                {
                    Id = 8,
                    CategoryId = 3,
                    Title = "Cube",
                    Director = "Vincenzo Natali",
                    Desc = "Grupa osób budzi się w pełnym śmiertelnych pułapek sześcianie. Nieznajomi muszą zacząć współpracować ze sobą, by przeżyć.",
                    Price = 15m,
                    PublishDate = new System.DateTime(2022, 12, 08),
                    PosterName = "cube.jpg"
                },
                new Film()
                {
                    Id = 9,
                    CategoryId = 1,
                    Title = "Hellraiser: Wysłannik Piekieł",
                    Director = "Clive Barker",
                    Desc = "Frank Cotton nabywa tajemniczą kostkę, za pomocą której można przywołać demony z piekła.",
                    Price = 16m,
                    PublishDate = new System.DateTime(2023, 01, 02),
                    PosterName = "hellriser.jpg"
                },
                new Film()
                {
                    Id = 10,
                    CategoryId = 3,
                    Title = "Milczenie Owiec",
                    Director = "Jonathan Demme",
                    Desc = "Seryjny morderca i inteligentna agentka łączą siły, by znaleźć przestępcę obdzierającego ze skóry swoje ofiary.",
                    Price = 17m,
                    PublishDate = new System.DateTime(2022, 02, 16),
                    PosterName = "milczenie-owiec.jpg"
                }
                );
        }
    }
}
