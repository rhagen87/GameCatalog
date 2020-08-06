using GameCatalog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.ViewModels
{
    public class EditGameViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public int DeveloperId { get; set; }
        public List<SelectListItem> Developers { get; set; }
        public List<int> GenreId { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public Game Game { get; set; }
        public List<SelectListItem> GameGenres { get; set; }
        public DateTime ReleaseDate { get; set; }

        public EditGameViewModel()
        {

        }

        public EditGameViewModel(Game game, List<Developer> developers, List<Genre> genres, List<GameGenre> gameGenres)
        {
            Genres = new List<SelectListItem>();
            Developers = new List<SelectListItem>();
            GameGenres = new List<SelectListItem>();
            Game = game;

            foreach (var developer in developers)
            {
                Developers.Add(new SelectListItem
                {
                    Value = developer.Id.ToString(),
                    Text = developer.Name
                });
            }

            foreach (var genre in genres)
            {
                Genres.Add(new SelectListItem
                {
                    Value = genre.Id.ToString(),
                    Text = genre.Name
                });
            }

            foreach (var gameGenre in gameGenres)
            {
                GameGenres.Add(new SelectListItem
                {
                    Value = gameGenre.GenreId.ToString(),
                    Text = gameGenre.GameId.ToString()
                });

            }
        }
    }
}
