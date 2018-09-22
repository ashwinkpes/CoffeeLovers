using CoffeeLovers.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace CoffeeLovers.Extensions
{
    public static class AddCorsPolicy
    {
        public static void AddCrossOriginPolicy(this IServiceCollection services, IConfiguration Configuration)
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
