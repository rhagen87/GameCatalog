using GameCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.Data
{
    public class GameDBContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public GameDBContext(DbContextOptions<GameDBContext> options) : base(options) { }
    }
}
