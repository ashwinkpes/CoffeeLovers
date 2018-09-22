using CoffeeLovers.Common;
using CoffeeLovers.DAL;
using CoffeeLovers.DomainModels.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CoffeeLovers.Extensions
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

                var seedData = new SeedData
                {
                    Areas = JsonConvert.DeserializeObject<List<Area>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "areas.json")),
                    Owners = JsonConvert.DeserializeObject<List<Owner>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "Owners.json")),
                    Coffees = JsonConvert.DeserializeObject<List<Coffee>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "Coffees.json")),
                };

                serviceScope.ServiceProvider.GetService<CoffeeDbContext>().EnsureSeedData(seedData);
            }
        }
    }
}
