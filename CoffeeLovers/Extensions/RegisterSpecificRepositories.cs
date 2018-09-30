using CoffeeLovers.IRepositories;
using CoffeeLovers.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterSpecificRepositories
    {
        internal static void RegisterSpecificRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAreaRepository), typeof(AreaRepository));
            services.AddScoped(typeof(ICoffeeRepository), typeof(CoffeeRepository));
            services.AddScoped(typeof(IOwnerRepository), typeof(OwnerRepository));

        }
    }
}
