using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Middleware.Authentication;

namespace YYA.OnionArchitecture.Middlewares
{
    public static class ServiceRegistrar
    {
        public static void AddCustomMiddlewares(this WebApplication webApplication)
        {
            webApplication.UseMiddleware<ExceptionHandler>();
        }

        public static void AddMiddlewareServices(this IServiceCollection serviceCollection , ConfigurationManager configuration)
        {
            serviceCollection.AddTransient<IAuthService, AuthService>();

            //jwt authentication
            serviceCollection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetValue<string>(IAuthService.KEY_JWT_ISSUER),
                    ValidAudience = configuration.GetValue<string>(IAuthService.KEY_JWT_AUDIENCE),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>(IAuthService.KEY_JWT_SECURITY_KEY)))
                };
            });

        }
    }
}
