using GameCatalog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.ViewModels
{
    public class AddGameViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Cover { get; set; }
        public int DeveloperId { get; set; }
        public List<SelectListItem> Developers { get; set; }
        public List<int> GenreId { get; set; }
        public List<SelectListItem> Genres { get; set; }

        public AddGameViewModel()
        {

        }

        public AddGameViewModel(List<Developer> developers, List<Genre> genres)
        {
            Genres = new List<SelectListItem>();
            Developers = new List<SelectListItem>();

            foreach (var developer in developers)
            {
                Developers.Add(new SelectListItem
                {
                    Value = developer.Id.ToString(),
                    Text = developer.Name
                });

            foreach (var genre in genres)
                {
                    Genres.Add(
                        new SelectListItem
                        {
                            Value = genre.Id.ToString(),
                            Text = genre.Name
                        });
                }
            }
        }
    }
}
