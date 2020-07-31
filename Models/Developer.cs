using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Developer() { }

        public Developer(string name)
        {
            Name = name;
        }
    }
}
