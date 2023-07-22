using SuperHero.Dominio.Interfaces;
using SuperHero.Dominio.Models;

namespace SuperHero.Infrastructure.Repositories
{
    public class HeroRepository : Repository<City>, IHeroRepository
    {
        public HeroRepository(AppDbContext context) : base(context)
        {
        }

    }
}
