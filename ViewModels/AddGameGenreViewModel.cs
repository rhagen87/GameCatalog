using GameCatalog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.ViewModels
{
    public class AddGameGenreViewModel
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public int GenreId { get; set; }
        public Game Game { get; set; }
        public List<SelectListItem> Genres { get; set; }

        public AddGameGenreViewModel(Game game, List<Genre> genres)
        {
            Genres = new List<SelectListItem>();

            foreach (var genre in genres)
            {
                Genres.Add(new SelectListItem
                {
                    Value = genre.Id.ToString(),
                    Text = genre.Name
                });
            }

            Game = game;
        }

        public AddGameGenreViewModel() { }
    }
}
