using CoffeeLovers.Common.Options;
using CoffeeLovers.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterOptions
    {
        internal static void AddChainOfOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //API settings
            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

            //SendGrid Settings
            services.Configure<SendGridSettings>(configuration.GetSection("SendGridSettings"));

            //BasicEmail Settings
            services.Configure<BasicEmailSettings>(configuration.GetSection("BasicEmailSettings"));

            services.AddTransient<Mail>();
            services.AddTransient<MailHelper>();

            //Cors settings
            var corsSettings = new CorsSettings();
            configuration.Bind("CorsPolicy", corsSettings);
            services.AddSingleton<CorsSettings>(corsSettings);
        }
    }
}