using CoffeeLovers.Common.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    public static class RegisterLogger
    {
        public static void RegisterLogging(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        }
    }
}
