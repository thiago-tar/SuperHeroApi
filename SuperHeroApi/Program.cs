
using SuperHero.Dominio.DI;
using SuperHero.Dominio.Interfaces;
using SuperHero.IOC;

namespace SuperHeroApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            Dependencies.Solver = new Solver();

            {
                var teste = Dependencies.Hero.Test();
            }
            {
                var s = Dependencies.Hero.Test();
            }

            var a = Hero.Id;
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}