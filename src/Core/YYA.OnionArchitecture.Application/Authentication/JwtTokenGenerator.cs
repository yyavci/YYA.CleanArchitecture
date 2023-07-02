using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Settings.Authentication;

namespace YYA.OnionArchitecture.Application.Authentication
{
    public class JwtTokenGenerator
    {
        private JwtSettings settings;
        public string? Token { get; private set; }
        public JwtSecurityToken SecurityToken { get; private set; }

        public JwtTokenGenerator(JwtSettings settings)
        {
            if(settings is null)
                throw new ArgumentNullException(nameof(settings));

            this.settings = settings;
        }

        public void GenerateToken(string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecurityKey!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddDays(settings.ExpirationDay);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
            };

            var token = new JwtSecurityToken(
                issuer: settings.Issuer,
                audience: settings.Audience,
                claims: claims,
                notBefore: null,
                expires: expiry,
                signingCredentials: credentials
                );

            SecurityToken = token;

            Token = new JwtSecurityTokenHandler().WriteToken(token);
        }








    }
}
