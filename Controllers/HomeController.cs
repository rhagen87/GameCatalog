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

        [HttpGet("Add")]
        public IActionResult AddGame()
        {
            List<Developer> developers = context.Developers.ToList();
            AddGameViewModel addGameViewModel = new AddGameViewModel(developers);
            return View(addGameViewModel);
        }

        public IActionResult ProcessAddGameForm(AddGameViewModel addGameViewModel)
        {
            if (ModelState.IsValid)
            {
                Developer developer = context.Developers.Find(addGameViewModel.DeveloperId);
                Game game = new Game
                {
                    Name = addGameViewModel.Name,
                    Description = addGameViewModel.Description,
                    Developer = developer
                };
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

            GameDetailViewModel viewModel = new GameDetailViewModel(game);
            return View(viewModel);
        }
    }
}
