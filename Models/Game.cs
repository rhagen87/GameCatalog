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
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Cover { get; set; }
        public float Rating { get; set; }
        public int GenreId { get; set; }
        public int DeveloperId { get; set; }

        public Game() { }

        public Game(string name, string description, DateTime releaseDate, string cover, float rating, int genreId, int developerId)
        {
            Name = name;
            Description = description;
            ReleaseDate = releaseDate;
            Cover = cover;
            Rating = rating;
            GenreId = genreId;
            DeveloperId = developerId;

        }
    }
}
