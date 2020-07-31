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
            List<Game> games = context.Games.ToList();
            return View(games);
        }

        public IActionResult Detail(int id)
        {
            Game game = context.Games
                .Single(g => g.Id == id);

            GameDetailViewModel viewModel = new GameDetailViewModel(game);
            return View(viewModel);
        }
    }
}
