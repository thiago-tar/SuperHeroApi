using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperHero.Dominio.Interfaces;
using SuperHero.Infrastructure;
using SuperHero.Infrastructure.Repositories;

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
            Scoped<ICityRepository, CityRepository>();
            Scoped<IUnitOfWork, UnitOfWork>();
        }

        private void RegisterEntityFramework()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultSQLConnection"));
            _builder.RegisterInstance(optionsBuilder.Options);
            _builder.RegisterType<AppDbContext>().InstancePerLifetimeScope();
        }
    }
}
