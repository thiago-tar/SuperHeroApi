global using Microsoft.EntityFrameworkCore;
using SuperHero.Dominio.Models;
using SuperHero.Infrastructure.EFConfigurations;
using System;

namespace SuperHero.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<City> City { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HeroConfiguration())
                        .ApplyConfiguration(new CityConfiguration());

        }



    }
}
