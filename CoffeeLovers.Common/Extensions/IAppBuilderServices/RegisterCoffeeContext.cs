using CoffeeLovers.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.Common.Extensions.IAppBuilderServices
{
    public static class RegisterCoffeeContext
    {
        public static void AddCoffeeContext(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<CoffeeDbContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:CoffeeLovers"]));
        }

        public static void SeedCoffeeContext(this IApplicationBuilder app, IConfiguration _configuration)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
              serviceScope.ServiceProvider.GetService<CoffeeDbContext>().EnsureSeedData();
            }
        }
    }
}
