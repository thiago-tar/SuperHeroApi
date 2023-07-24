using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperHero.Aplication.Service;
using SuperHero.Dominio.Authentication;
using SuperHero.Dominio.Authentication.Interfaces;
using SuperHero.Dominio.Interfaces;
using SuperHero.Dominio.Interfaces.Services;
using SuperHero.Infrastructure;
using SuperHero.Infrastructure.Authentication;
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
            RegisterServices();
            RegisterAuthnetication();
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

        private void RegisterServices()
        {
            Scoped<IAuthenticationService, AuthenticationService>();
        }

        private void RegisterAuthnetication()
        {
            Singleton(_config.GetSection(JwtSettings.JwtSection).Get<JwtSettings>());
            Singleton<IJwtTokenGenerator, JwtTokenGenerator>();
        }
    }
}
