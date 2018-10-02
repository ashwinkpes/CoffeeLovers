using CoffeeLovers.NotificationService;
using CoffeeLovers.NotificationService.Message;
using System.Threading.Tasks;

namespace CoffeeLovers.Helpers
{
    internal class Mail
    {
        private readonly IAzureEmailSender _azureEmailSender;

        Mail(IAzureEmailSender azureEmailSender)
        {
            _azureEmailSender = azureEmailSender;
        }

        internal async Task<ResponseMessage> SendMailAsync(EmailMessage message)
        {
           return await _azureEmailSender.SendAsync(message);
        }
    }
}
