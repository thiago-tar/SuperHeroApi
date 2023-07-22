using SuperHero.Dominio.DI;
using SuperHero.IOC;

namespace SuperHero.API
{
    public static class AppExtension
    {
        public static void DependencyInjectionAutoFac(this WebApplication app)
        {
            Dependencies.Solver = new Solver(app.Configuration);
        }
    }
}
