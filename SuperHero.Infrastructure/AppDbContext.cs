global using Microsoft.EntityFrameworkCore;
using SuperHero.Dominio.Models;
using System;

namespace SuperHero.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<City> Contatos { get; set; }
    }
}
