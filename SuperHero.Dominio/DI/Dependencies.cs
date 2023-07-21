using SuperHero.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static IHero Hero { get => Solver.Solve<IHero>(); }

        }
}
