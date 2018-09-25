using CoffeeLovers.Common.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterLogger
    {
        internal static void RegisterLogging(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        }
    }
}
