using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameCatalog.Models;
using GameCatalog.Data;
using Microsoft.EntityFrameworkCore;
using GameCatalog.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameCatalog.Controllers
{
    public class HomeController : Controller
    {
        private GameDBContext context;
        public HomeController(GameDBContext dBContext)
        {
            context = dBContext;
        }
        public IActionResult Index()
        {
            List<Game> games = context.Games
                .Include(g => g.Developer)
                .ToList();
            return View(games);
        }
        [HttpGet("/Add")]
        public IActionResult AddGame()
        {
            List<Developer> developers = context.Developers.ToList();
            List<Genre> genres = context.Genres.ToList();
            AddGameViewModel addGameViewModel = new AddGameViewModel(developers, genres);
            return View(addGameViewModel);
        }
        public IActionResult ProcessAddGameForm(AddGameViewModel addGameViewModel, string[] selectedGenres)
        {
            if (ModelState.IsValid)
            {
                Developer developer = context.Developers.Find(addGameViewModel.DeveloperId);
                Game game = new Game
                {
                    Name = addGameViewModel.Name,
                    Description = addGameViewModel.Description,
                    Cover = addGameViewModel.Cover,
                    ReleaseDate = addGameViewModel.ReleaseDate,
                    Developer = developer
                };

                foreach (string genre in selectedGenres) 
                {
                    GameGenre gameGenre = new GameGenre
                    {
                        Game = game,
                        GameId = game.Id,
                        GenreId = int.Parse(genre)
                    };
                    context.GameGenres.Add(gameGenre);
                }
                context.Games.Add(game);
                context.SaveChanges();

                return Redirect("Index");
            }
            return View("AddGame", addGameViewModel);
        }
        public IActionResult Detail(int id)
        {
            Game game = context.Games
                .Include(g => g.Developer)
                .Single(g => g.Id == id);

            List<GameGenre> gameGenres = context.GameGenres
                .Where(gg => gg.GameId == id)
                .Include(gg => gg.Genre)
                .ToList();

            GameDetailViewModel viewModel = new GameDetailViewModel(game, gameGenres);
            return View(viewModel);
        }
        [Route("Home/Edit/{Id}")]
        public IActionResult Edit(int id)
        {
            Game game = context.Games.Find(id);
            List<Developer> developers = context.Developers.ToList();
            List<Genre> genres = context.Genres.ToList();
            List<GameGenre> gameGenres = context.GameGenres.ToList();
            EditGameViewModel viewModel = new EditGameViewModel(game, developers, genres, gameGenres);
            return View(viewModel);
        }
        [HttpPost]
        [Route("Home/Edit")]
        public IActionResult SubmitEditGameForm(int id, string name, string description)
        {
            Game game = context.Games.Find(id);

            game.Name = name;
            game.Description = description;
            context.SaveChanges();
            return Redirect("Index");

        }
    }
}
