using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YYA.OnionArchitecture.Application.Settings.Authentication;
using Serilog;
using Serilog.Events;
using Newtonsoft.Json;

namespace YYA.OnionArchitecture.Middlewares
{
    public static class ServiceRegistrar
    {
        public static void AddCustomMiddlewares(this WebApplication webApplication)
        {
            webApplication.UseMiddleware<ExceptionHandler>();
            webApplication.UseSerilogRequestLogging(options =>
            {
                // Customize the message template
                options.MessageTemplate = "-> {RequestMethod} {StatusCode} {RequestPath} [{Elapsed:0.000}ms] ";

                // Emit debug-level events instead of the defaults
                options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;
                
                // Attach additional properties to the request completion event
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                };
            });
        }

        public static void AddMiddlewareServices(this WebApplicationBuilder builder)
        {
            AddSeriLog(builder);
            AddJwt(builder.Services, builder.Configuration);
        }

        private static void AddJwt(IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            //jwt authentication
            var jwtSection = configuration.GetSection(nameof(JwtSettings));
            serviceCollection.Configure<JwtSettings>(opt => jwtSection.Bind(opt));
            var jwtSettings = jwtSection.Get<JwtSettings>();

            if (jwtSettings is null)
                return;

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey!))
                };
            });
        }

        private static void AddSeriLog(WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Host.UseSerilog();



        }
    }
}
