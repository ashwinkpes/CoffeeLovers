using CoffeeLovers.Common;
using CoffeeLovers.DAL;
using CoffeeLovers.DomainModels.Models;
using CoffeeLovers.IBusinessLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterCoffeeContext
    {
        internal static void AddCoffeeContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoffeeDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:CoffeeLovers"],
                 serverDbContextOptionsBuilder =>
                 {
                     var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                     serverDbContextOptionsBuilder.CommandTimeout(minutes);
                     serverDbContextOptionsBuilder.EnableRetryOnFailure();
                 }));
        }

        internal static void SeedCoffeeContext(this IApplicationBuilder app, ISecurityService securityService, string userInitializePassword)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var seedData = new SeedData
                {
                    Areas = JsonConvert.DeserializeObject<List<Area>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "areas.json")),
                    Owners = JsonConvert.DeserializeObject<List<Owner>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "Owners.json")),
                    Coffees = JsonConvert.DeserializeObject<List<Coffee>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "Coffees.json")),
                    Roles = JsonConvert.DeserializeObject<List<Role>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "Roles.json")),
                    UserInitalizePassword =  userInitializePassword
                };

                serviceScope.ServiceProvider.GetService<CoffeeDbContext>().EnsureSeedData(seedData, securityService);
            }
        }
    }
}
