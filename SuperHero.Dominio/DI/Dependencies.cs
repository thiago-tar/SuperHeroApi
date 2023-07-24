using SuperHero.Dominio.Authentication.Interfaces;
using SuperHero.Dominio.Interfaces;
using SuperHero.Dominio.Interfaces.Services;

namespace SuperHero.Dominio.DI
{
    public static class Dependencies
    {
        private static ISolver _solver;
        private static object _lock = new object();

        public static ISolver Solver
        {
            get
            {
                lock (_lock)
                {
                    if (_solver == null)
                        throw new SolveNotImplemented("Solver has not been Implemented");

                    return _solver;
                }
            }
            set
            {
                lock (_lock)
                {
                    _solver = value;
                }
            }
        }

        public static IHeroRepository HeroRepository { get => Solver.Resolve<IHeroRepository>(); }

        public static IUnitOfWork UnitOfWork { get => Solver.Resolve<IUnitOfWork>(); }

        public static ICityRepository CityRepository { get => Solver.Resolve<ICityRepository>(); }

        public static IAuthenticationService AuthenticationService { get => Solver.Resolve<IAuthenticationService>(); }

        public static IJwtTokenGenerator JwtTokenGenerator { get => Solver.Resolve<IJwtTokenGenerator>(); }

    }
}
