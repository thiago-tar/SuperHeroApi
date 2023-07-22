using SuperHero.Dominio.Interfaces;
using SuperHero.Dominio.Models;

namespace SuperHero.Infrastructure.Repositories
{
    public class HeroRepository : Repository<Hero>, IHeroRepository
    {
        public HeroRepository(AppDbContext context) : base(context)
        {
        }

    }
}
