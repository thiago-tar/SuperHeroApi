using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Dominio.DI
{
    public class SolveNotImplemented : Exception
    {
        public SolveNotImplemented()
        {
        }

        public SolveNotImplemented(string? message) : base(message)
        {
        }
    }
}
