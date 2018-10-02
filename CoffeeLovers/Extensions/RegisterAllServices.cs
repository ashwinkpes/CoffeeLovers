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

            //Add Ioptions and other settings
            services.AddChainOfOptions(configuration);

            //Add Notification services
            services.AddNotificationService(configuration);

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