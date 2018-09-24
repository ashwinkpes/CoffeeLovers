using CoffeeLovers.BusinessLogic;
using CoffeeLovers.IBusinessLogic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.Extensions
{
    public static class RegisterBusinessServices
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IAreaService, AreaService>();
        }
    }
}
