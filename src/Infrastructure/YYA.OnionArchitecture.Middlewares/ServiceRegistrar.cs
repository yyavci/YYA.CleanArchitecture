using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YYA.OnionArchitecture.Application.Authentication;
using YYA.OnionArchitecture.Application.Settings.Authentication;

namespace YYA.OnionArchitecture.Middlewares
{
    public static class ServiceRegistrar
    {
        public static void AddCustomMiddlewares(this WebApplication webApplication)
        {
            webApplication.UseMiddleware<ExceptionHandler>();
        }

        public static void AddMiddlewareServices(this IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            //jwt authentication
            var jwtSection = configuration.GetSection(nameof(JwtSettings));
            serviceCollection.Configure<JwtSettings>(opt => jwtSection.Bind(opt));
            var jwtSettings = jwtSection.Get<JwtSettings>();

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
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey))
                };
            });
        }
    }
}
