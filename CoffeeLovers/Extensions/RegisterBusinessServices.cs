using CoffeeLovers.BusinessLogic;
using CoffeeLovers.IBusinessLogic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
