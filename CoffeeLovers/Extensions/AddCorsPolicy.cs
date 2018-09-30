using CoffeeLovers.Common.Options;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    internal static class AddCorsPolicy
    {
        internal static void AddCrossOriginPolicy(this IServiceCollection services)
        {
            CorsSettings corsSettings = default(CorsSettings);

            var sp = services.BuildServiceProvider();
            corsSettings = (CorsSettings)sp.GetService(typeof(CorsSettings));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .WithOrigins(corsSettings.AllowedOrgins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }
    }
}