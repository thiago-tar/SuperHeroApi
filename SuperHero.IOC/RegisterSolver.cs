using SuperHero.Dominio.Interfaces;
using SuperHero.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.IOC
{
    public partial class Solver
    {
        private void Register()
        {
            Singleton(_config);
            RegisterEntityFramework();
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            Scoped<IHeroRepository, HeroRepository>();
            Scoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
