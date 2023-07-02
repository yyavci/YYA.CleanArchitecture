using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Settings;
using YYA.OnionArchitecture.Application.Settings.Authentication;

namespace YYA.OnionArchitecture.Application
{
    public static class ServiceRegistrar
    {
        public static void AddApplicationServices(this WebApplicationBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.Services.AddAutoMapper(assembly);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            builder.Services.AddValidatorsFromAssembly(assembly);

        }
    }
}
