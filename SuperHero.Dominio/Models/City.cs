using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Dominio.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Hero> Heros { get; set; }
    }
}
