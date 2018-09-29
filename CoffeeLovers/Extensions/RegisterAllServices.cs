using CoffeeLovers.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterAllServices
    {
        internal static void RegisterChainOfServices(this IServiceCollection services, IConfiguration Configuration)
        {
             //Add options
            services.AddOptions();
            services.AddHttpContextAccessor();

            //services.Configure<CorsSettings>(Configuration.GetSection("CorsPolicy"));

            //API settings
            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));

            //Cors settings
            var CorsSettings = new CorsSettings();
            Configuration.Bind("CorsPolicy", CorsSettings);
            services.AddSingleton<CorsSettings>(CorsSettings);

            //Add extesnion methods

            //Add DB context
            services.AddCoffeeContext(Configuration);

            //Add logging
            services.RegisterLogging(Configuration);

            //Add HttpContext Accessor
            services.RegisterAccessor(Configuration);

            //Add Cors
            services.AddCrossOriginPolicy(Configuration);

            //Add generic repositories
            services.RegisterRepository(Configuration);

            //Add specific repositories
            services.RegisterSpecificRepository(Configuration);

            //Register services
            services.RegisterServices(Configuration);

            //Register Swagger
            services.AddSwaggerSettings(Configuration);
        }
    }
}
