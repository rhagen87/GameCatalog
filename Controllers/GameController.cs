using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCatalog.Data;
using GameCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.Controllers
{
    public class GameController : Controller
    {
        private GameDBContext context;

        public GameController(GameDBContext dBContext)
        {
            context = dBContext;
        }
        public IActionResult Index()
        {
            List<Game> games = context.Games.ToList();
            return View(games);
        }
    }
}
