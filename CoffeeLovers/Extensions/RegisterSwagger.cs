using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterSwagger
    {
        internal static void AddSwaggerSettings(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Coffee Lovers",
                    Description = "An application to provide details of coffee sales",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "CoffeeLoveersAdmin",
                        Email = "CoffeeLoveersAdmin@Gamil.com",
                        Url = "https://twitter.com/ashwinkpes"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
          
        }

        internal static void UseSwaggerMiddleWare(this IApplicationBuilder app, IConfiguration _configuration)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cofee Lovers API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
