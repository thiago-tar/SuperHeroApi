using SuperHero.Dominio.Interfaces;
using SuperHero.Dominio.Models;

namespace SuperHero.Infrastructure.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }
    }
}
