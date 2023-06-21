using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Repositories;
using YYA.OnionArchitecture.Persistence.Context;
using YYA.OnionArchitecture.Persistence.Repositories;

namespace YYA.OnionArchitecture.Persistence
{
    public static class ServiceRegistrar
    {
        public static void AddPersistanceServices(this IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
                serviceCollection.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("memoryDatabase"));


            serviceCollection.AddTransient<IProductRepository, ProductRepository>();


        }

    }
}
