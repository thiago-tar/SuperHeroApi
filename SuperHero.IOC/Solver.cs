using Autofac;
using Autofac.Core.Activators;
using Microsoft.Extensions.Configuration;
using SuperHero.Dominio.DI;
using SuperHero.Dominio.Entities;
using SuperHero.Dominio.Interfaces;

namespace SuperHero.IOC
{
    public class Solver : ISolver
    {
        private readonly ContainerBuilder _builder;
        private readonly IContainer _container;

        public Solver()
        {
            _builder = new ContainerBuilder();
            Scoped<IHero,Hero>();

            _container = _builder.Build();
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

        private void Transient<T1, T2>() where T2 : T1
        {
            _builder.RegisterType<T2>().As<T1>().InstancePerDependency();
        }

        private static T LeConfiguracao<T>(string secao) =>
            new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("configuracao.json")
            .Build()
            .GetSection(secao)
            .Get<T>();
    }
}
