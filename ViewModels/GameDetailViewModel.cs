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
        public string GenreText { get; set; }
        public string DeveloperName { get; set; }
        public DateTime ReleaseDate { get; set; }

        public GameDetailViewModel(Game game, List<GameGenre> gameGenres)
        {
            GameId = game.Id;
            Name = game.Name;
            Description = game.Description;
            Cover = game.Cover;
            DeveloperName = game.Developer.Name;
            ReleaseDate = game.ReleaseDate;

            GenreText = "";
            for (int i = 0; i < gameGenres.Count; i++)
            {
                GenreText += gameGenres[i].Genre.Name;
                if (i < gameGenres.Count - 1)
                {
                    GenreText += ", ";
                }
            }
        }
    }
}
