using CoffeeLovers.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterAllServices
    {
        internal static void RegisterChainOfServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Add options
            services.AddOptions();
            services.AddHttpContextAccessor();

            //services.Configure<CorsSettings>(Configuration.GetSection("CorsPolicy"));

            //API settings
            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

            //Cors settings
            var corsSettings = new CorsSettings();
            configuration.Bind("CorsPolicy", corsSettings);
            services.AddSingleton<CorsSettings>(corsSettings);

           //Add DB context
            services.AddCoffeeContext(configuration);

            //Add logging
            services.RegisterLogging();

            //Add HttpContext Accessor
            services.RegisterAccessor();

            //Add Cors
            services.AddCrossOriginPolicy();

            //Add generic repositories
            services.RegisterRepository();

            //Add specific repositories
            services.RegisterSpecificRepository();

            //Register services
            services.RegisterServices();

            //Register Swagger
            services.AddSwaggerSettings();
        }
    }
}
