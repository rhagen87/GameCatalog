using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.Models
{
    public class Game
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Cover { get; set; }
        public float Rating { get; set; }
        public int GenreId { get; set; }
        public Developer Developer { get; set; }
        public int DeveloperId { get; set; }

        public Game() { }

        public Game(string name)
        {
            Name = name;
        }
    }
}
