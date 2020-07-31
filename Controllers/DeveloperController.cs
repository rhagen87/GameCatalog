using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCatalog.Data;
using GameCatalog.Models;
using GameCatalog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.Controllers
{
    public class DeveloperController : Controller
    {
        private GameDBContext context;
        public DeveloperController(GameDBContext dBContext)
        {
            context = dBContext;
        }

        public IActionResult Index()
        {
            List<Developer> developers = context.Developers.ToList();
            return View(developers);
        }

        public IActionResult Add()
        {
            AddDeveloperViewModel addDeveloperViewModel = new AddDeveloperViewModel();
            return View(addDeveloperViewModel);
        }

        public IActionResult ProcessAddDeveloperForm(AddDeveloperViewModel addDeveloperViewModel)
        {
            if (ModelState.IsValid)
            {
                Developer developer = new Developer
                {
                    Name = addDeveloperViewModel.Name
                };

                context.Developers.Add(developer);
                context.SaveChanges();

                return Redirect("Index");
            }
            return View("Add", addDeveloperViewModel);
        }

        public IActionResult About(int id)
        {
            Developer developer = context.Developers.Find(id);
            return View(developer);
        }
    }
}
