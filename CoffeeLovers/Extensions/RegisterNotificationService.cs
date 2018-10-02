using CoffeeLovers.NotificationService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeLovers.Extensions
{
    internal static class RegisterNotificationService
    {
        internal static void AddNotificationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAzureEmailSender>(s => new AzureEmailSender(new AzureEmailSettings(configuration["SendGridSettings:ApiKey"])));
        }
    }
}