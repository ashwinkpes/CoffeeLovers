using CoffeeLovers.NotificationService.Message;
using System.Threading.Tasks;

namespace CoffeeLovers.NotificationService
{
    public interface IAzureEmailSender
    {
        Task<ResponseMessage> SendAsync(EmailMessage message);
    }
}