using SuperHero.Dominio.Interfaces;

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

        public static IHeroRepository HeroRepository { get => Solver.Solve<IHeroRepository>(); }

        public static IUnitOfWork UnitOfWork { get => Solver.Solve<IUnitOfWork>(); }

        public static ICityRepository CityRepository { get => Solver.Solve<ICityRepository>(); }

    }
}
