using Microsoft.AspNetCore.Mvc;
using SuperHero.Dominio.Authentication;
using SuperHero.Dominio.DI;

namespace SuperHero.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("register")]
        public ActionResult Register(RegisterRequest register)
        {
            var authResult = Dependencies.AuthenticationService.Register(register.FirstName, register.LasName, register.Email, register.Password);
            var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LasName,
                authResult.Email,
                authResult.Token
                );
            return Ok(response);
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginRequest register)
        {
            var authResult = Dependencies.AuthenticationService.Login(register.Email, register.Password);
            var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LasName,
                authResult.Email,
                authResult.Token
                );
            return Ok(response);
        }
    }
}
