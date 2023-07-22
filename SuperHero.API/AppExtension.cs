using AutoMapper;
using SuperHero.API.DTOs;
using SuperHero.Dominio.DI;
using SuperHero.Dominio.Models;
using SuperHero.IOC;

namespace SuperHero.API
{
    public static class AppExtension
    {
        public static void DependencyInjectionAutoFac(this WebApplication app)
        {
            Dependencies.Solver = new Solver(app.Configuration);
        }

        public static void AutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x =>
            {
                x.CreateMap<Hero, HeroDTO>();
                x.CreateMap<HeroDTO, Hero>();
                x.CreateMap<CityDTO, City>();
                x.CreateMap<City, CityDTO>();
            });
        }
    }
}
