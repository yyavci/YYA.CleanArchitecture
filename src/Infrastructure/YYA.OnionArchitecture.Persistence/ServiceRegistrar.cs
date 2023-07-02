using Microsoft.AspNetCore.Builder;
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
        public static void AddPersistanceServices(this WebApplicationBuilder builder)
        {
            if (builder.Configuration.GetValue<bool>("UseInMemoryDatabase"))
                builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("memoryDatabase"));


            builder.Services.AddTransient<IProductRepository, ProductRepository>();


        }

    }
}
