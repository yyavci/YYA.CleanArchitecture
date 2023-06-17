using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYA.CleanArchitecture.Middlewares
{
    public static class ServiceRegistrar
    {
        public static void AddCustomMiddlewares(this WebApplication webApplication)
        {

            webApplication.UseMiddleware<ExceptionHandler>();


        }
    }
}
