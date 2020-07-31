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

        public AddGameViewModel()
        {

        }

        public AddGameViewModel(List<Developer> developers)
        {
            Developers = new List<SelectListItem>();

            foreach (var developer in developers)
            {
                Developers.Add(new SelectListItem
                {
                    Value = developer.Id.ToString(),
                    Text = developer.Name
                });
            }
        }
    }
}
