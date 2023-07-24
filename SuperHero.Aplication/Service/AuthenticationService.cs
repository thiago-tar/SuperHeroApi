using SuperHero.Dominio.Authentication;
using SuperHero.Dominio.DI;
using SuperHero.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Aplication.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Login(string email, string password)
        {
              return new AuthenticationResult(Guid.NewGuid(),string.Empty,string.Empty,email,password);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            Guid userId = Guid.NewGuid();
            var token = Dependencies.JwtTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(userId, firstName, lastName, email, token); 
        }
    }
}
