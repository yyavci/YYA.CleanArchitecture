using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYA.OnionArchitecture.Middleware.Authentication
{
    public interface IAuthService
    {
        public const string KEY_JWT_SECURITY_KEY = "JwtSecurityKey";
        public const string KEY_JWT_ISSUER = "JwtIssuer";
        public const string KEY_JWT_AUDIENCE = "JwtAudience";
        public const string KEY_JWT_EXPIRATION_DAYS = "JwtExpirationDays";
        string GenerateJwtToken(string email);
    }
}
