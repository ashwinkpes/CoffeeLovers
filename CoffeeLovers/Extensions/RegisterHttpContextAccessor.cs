using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterHttpContextAccessor
    {
        internal static void RegisterAccessor(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }
    }
}
