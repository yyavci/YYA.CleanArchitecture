using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YYA.OnionArchitecture.Application
{
    public static class ServiceRegistrar
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            serviceCollection.AddAutoMapper(assembly);
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            serviceCollection.AddValidatorsFromAssembly(assembly);

        }
    }
}
