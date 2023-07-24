using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SuperHero.Dominio.Authentication;
using SuperHero.Dominio.Authentication.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;  

namespace SuperHero.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        public JwtTokenGenerator(JwtSettings jwtSettings)
        {
            _jwtSettings= jwtSettings;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials,
                audience: _jwtSettings.Audience);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
