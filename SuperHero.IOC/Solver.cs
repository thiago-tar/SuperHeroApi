using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperHero.Dominio.DI;
using SuperHero.Dominio.Interfaces;
using SuperHero.Infrastructure;
using SuperHero.Infrastructure.Repositories;

namespace SuperHero.IOC
{
    public partial class Solver : ISolver
    {
        private readonly ContainerBuilder _builder;
        private readonly IContainer _container;
        private readonly IConfiguration _config;

        public Solver(IConfiguration config)
        {
            _config = config;
            _builder = new ContainerBuilder();
            Register();
            _container = _builder.Build();
        }

        private void RegisterEntityFramework()
        {
            var options = _builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultSQLConnection"));
                return new AppDbContext(optionsBuilder.Options);
            });
        }

        public T Solve<T>() => _container.Resolve<T>();

        private void Singleton<T>(T instance) where T : class
        {
            _builder.RegisterInstance(instance).As<T>().SingleInstance();
        }

        private void Singleton<T1, T2>() where T2 : T1
        {
            _builder.RegisterType<T2>().As<T1>().SingleInstance();
        }

        private void Scoped<T1, T2>() where T2 : T1
        {
            _builder.RegisterType<T2>().As<T1>().InstancePerLifetimeScope();
        }

        private void Scoped<T>(T instance) where T : class
        {
            _builder.RegisterInstance(instance).As<T>().InstancePerLifetimeScope();
        }

        private void Transient<T1, T2>() where T2 : T1
        {
            _builder.RegisterType<T2>().As<T1>().InstancePerDependency();
        }

        private static T GetSection<T>(string jsonFile, string section) =>
             GetConfiguration(jsonFile)
            .GetSection(section)
            .Get<T>();

        private static IConfiguration GetConfiguration(string jsonFile) =>
            new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(jsonFile)
            .Build();
    }
}
