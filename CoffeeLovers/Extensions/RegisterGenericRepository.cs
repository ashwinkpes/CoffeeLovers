using CoffeeLovers.IRepositories;
using CoffeeLovers.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterGenericRepository
    {
        internal static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IDictionaryRepsository<>), typeof(DictionaryRepsository<>));
        }
    }
}
