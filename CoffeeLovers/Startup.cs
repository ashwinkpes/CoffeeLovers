using CoffeeLovers.Common.Options;
using CoffeeLovers.Extensions;
using CoffeeLovers.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc(config => {
                config.Filters.Add(typeof(GlobalExceptionhandler));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

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

            //Register services
            services.RegisterServices(Configuration);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.SeedCoffeeContext(Configuration);
        }
    }
}
