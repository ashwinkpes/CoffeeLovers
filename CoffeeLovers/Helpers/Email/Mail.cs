using CoffeeLovers.NotificationService;
using CoffeeLovers.NotificationService.Message;
using System.Threading.Tasks;

namespace CoffeeLovers.Helpers
{
    public class Mail
    {
        private readonly IAzureEmailSender _azureEmailSender;

        public Mail(IAzureEmailSender azureEmailSender)
        {
            _azureEmailSender = azureEmailSender;
        }

        public async Task<ResponseMessage> SendMailAsync(EmailMessage message)
        {
            return await _azureEmailSender.SendAsync(message);
        }
    }
}