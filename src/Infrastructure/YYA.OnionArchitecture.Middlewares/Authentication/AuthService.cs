using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace YYA.OnionArchitecture.Middleware.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;

        public AuthService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateJwtToken(string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>(IAuthService.KEY_JWT_SECURITY_KEY)));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddDays(configuration.GetValue<int>(IAuthService.KEY_JWT_EXPIRATION_DAYS));

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
            };

            var token = new JwtSecurityToken(
                issuer: configuration.GetValue<string>(IAuthService.KEY_JWT_ISSUER),
                audience: configuration.GetValue<string>(IAuthService.KEY_JWT_ISSUER),
                claims: claims,
                notBefore: null,
                expires: expiry,
                signingCredentials: credentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
