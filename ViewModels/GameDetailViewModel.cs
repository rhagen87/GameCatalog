using GameCatalog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.ViewModels
{
    public class GameDetailViewModel
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }

        public GameDetailViewModel(Game game)
        {
            GameId = game.Id;
            Name = game.Name;
            Description = game.Description;
            Cover = game.Cover;
        }
    }
}
