using CoffeeLovers.IRepositories;
using CoffeeLovers.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterSpecificRepositories
    {
        internal static void RegisterSpecificRepository(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped(typeof(IAreaRepository), typeof(AreaRepository));
            services.AddScoped(typeof(ICoffeeRepository), typeof(CoffeeRepository));

        }
    }
}
