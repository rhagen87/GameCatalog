using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCatalog.Data;
using GameCatalog.Models;
using GameCatalog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.Controllers
{
    public class GenreController : Controller
    {
        private GameDBContext context;
        public GenreController(GameDBContext dBContext)
        {
            context = dBContext;
        }

        public IActionResult Index()
        {
            List<Genre> genres = context.Genres.ToList();
            return View(genres);
        }

        public IActionResult Add()
        {
            Genre genre = new Genre();
            return View(genre);
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            if (ModelState.IsValid)
            {
                context.Genres.Add(genre);
                context.SaveChanges();
                return Redirect("/Genre/");
            }

            return View("Add", genre);
        }

        public IActionResult AddGame(int id)
        {
            Game game = context.Games.Find(id);
            List<Genre> genres = context.Genres.ToList();
            AddGameGenreViewModel model = new AddGameGenreViewModel(game, genres);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddGame(AddGameGenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                int gameId = model.GameId;
                int genreId = model.GenreId;

                List<GameGenre> existingItems = context.GameGenres
                    .Where(gg => gg.GameId == gameId)
                    .Where(gg => gg.GenreId == genreId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    GameGenre gameGenre = new GameGenre
                    {
                        GameId = gameId,
                        GenreId = genreId
                    };
                    context.GameGenres.Add(gameGenre);
                    context.SaveChanges();
                }
                return Redirect("/Home/Detail/" + gameId);
            }
            return View(model);
        }

        public IActionResult About(int id)
        {
            List<GameGenre> gameGenres = context.GameGenres
                .Where(gg => gg.GenreId == id)
                .Include(gg => gg.Game)
                .Include(gg => gg.Genre)
                .ToList();

            return View(gameGenres);
        }
    }
}
