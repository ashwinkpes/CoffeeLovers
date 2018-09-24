using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    public static class RegisterHttpContextAccessor
    {
        public static void RegisterAccessor(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpContextAccessor();
        }
    }
}
